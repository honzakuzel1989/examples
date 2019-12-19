using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InterviewAssignments.IdentityService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InterviewAssignments.IdentityService.Tests
{
    [TestClass]
    public class IdentityServiceTests
    {
        [TestMethod]
        public void AuthenticationTest()
        {
            // Arrange

            var service = IdentityServiceFactory.CreateFromMemory(new List<string> {"jsmith"}, new List<string> {"jane123."});

            // Act

            var result1 = service.Authenticate("jsmitch", "jane123.");
            var result2 = service.Authenticate("jsmith", "jane123");
            var result3 = service.Authenticate("jsmith", "jane123.");
            var result4 = service.Authenticate("jSmith", "jane123.");
            var result5 = service.Authenticate("jSmith", "Jane123.");

            // Assert

            Assert.IsFalse(result1.IsSuccessful);
            Assert.AreEqual(AuthenticationError.UserNotFound, result1.Error);
            Assert.IsNull(result1.Properties);
            Assert.IsNull(result1.OriginalUserName);

            Assert.IsFalse(result2.IsSuccessful);
            Assert.AreEqual(AuthenticationError.InvalidPassword, result2.Error);

            Assert.IsTrue(result3.IsSuccessful);
            Assert.IsNull(result3.Error);
            Assert.IsFalse(result3.Properties.Any());

            Assert.IsTrue(result4.IsSuccessful);
            Assert.IsNull(result4.Error);

            Assert.IsFalse(result5.IsSuccessful);
            Assert.AreEqual(AuthenticationError.InvalidPassword, result5.Error);
        }

        [TestMethod]
        public void RegistrationTest()
        {
            // Arrange

            var service = IdentityServiceFactory.CreateFromMemory(new List<string> {"janeSmith"}, new List<string> {"john123."});

            var customProperties = new Dictionary<string, string>
            {
                {"Prop1", "Val1"},
                {"Prop2", "Val2"}
            };

            // Act

            var result1 = service.Authenticate("jsmith", "jane123.");
            var result2 = service.Register("jSmith", "jane123.", customProperties);
            var result3 = service.Authenticate("jsmith", "jane123.");
            var result4 = service.Authenticate("jSmith", "jane123.");
            var result5 = service.Register("jsmith", "jane123.");

            var result6 = service.Register("JaneSmith", "john123.");

            // Assert

            Assert.IsFalse(result1.IsSuccessful);
            Assert.AreEqual(AuthenticationError.UserNotFound, result1.Error);

            Assert.IsTrue(result2.IsSuccessful);
            Assert.IsNull(result2.Error);


            Assert.IsTrue(result3.IsSuccessful);
            Assert.IsNull(result3.Error);
            Assert.AreEqual("jSmith", result3.OriginalUserName);
            Assert.AreEqual(2, result3.Properties.Count);
            Assert.AreEqual(customProperties["Prop1"], result3.Properties["Prop1"]);
            Assert.AreEqual(customProperties["Prop2"], result3.Properties["Prop2"]);


            Assert.IsTrue(result4.IsSuccessful);
            Assert.IsNull(result4.Error);

            Assert.IsFalse(result5.IsSuccessful);
            Assert.AreEqual(RegistrationError.UserAlreadyExists, result5.Error);

            Assert.IsFalse(result6.IsSuccessful);
            Assert.AreEqual(RegistrationError.UserAlreadyExists, result6.Error);
        }


        [TestMethod]
        public void SavingToFileTest()
        {
            // Arrange

            var filePath = $"{Guid.NewGuid()}.json";
            var customProperties = new Dictionary<string, string>
            {
                {"Prop1", "Val1"},
                {"Prop2", "Val2"}
            };

            var service1 = IdentityServiceFactory.CreateFromMemory(new List<string> {"jsmith"}, new List<string> {"jane123."});

            // Act

            var result1 = service1.Authenticate("JaneSmith", "john123.");
            var result2 = service1.Register("JaneSmith", "john123.");
            var result3 = service1.Register("JaneSmithX", "john123.X", customProperties);

            service1.SaveToJson(filePath);

            var fileContents = File.ReadAllText(filePath);

            var service2 = IdentityServiceFactory.CreateFromJson(filePath);

            var result4 = service2.Authenticate("jsmiTh", "jane123.");
            var result5 = service2.Authenticate("janESmith", "john123.");
            var result6 = service2.Authenticate("janeSmithX", "john123.X");

            // Assert

            Assert.IsFalse(result1.IsSuccessful);
            Assert.IsTrue(result2.IsSuccessful);
            Assert.IsTrue(result3.IsSuccessful);

            Assert.IsTrue(result4.IsSuccessful);
            Assert.IsTrue(result5.IsSuccessful);
            Assert.AreEqual("JaneSmith", result5.OriginalUserName);
            Assert.IsFalse(result5.Properties.Any());

            Assert.IsTrue(result6.IsSuccessful);
            Assert.AreEqual("JaneSmithX", result6.OriginalUserName);
            Assert.AreEqual(2, result6.Properties.Count);
            Assert.AreEqual(customProperties["Prop1"], result6.Properties["Prop1"]);
            Assert.AreEqual(customProperties["Prop2"], result6.Properties["Prop2"]);

            try
            {
                var fileJson = JToken.Parse(fileContents);

                AssertCamelCaseJson(fileJson);
            }
            catch (JsonException ex)
            {
                Assert.Fail($"Invalid JSON format: {ex.Message}");
            }


            Assert.ThrowsException<ArgumentException>(() => service1.SaveToJson(filePath));

            // Cleanup in case of success

            File.Delete(filePath);
        }

        private void AssertCamelCaseJson(JToken token)
        {
            if (token is JObject obj)
            {
                Assert.IsTrue(obj.Properties().Select(p => p.Name.First()).All(char.IsLower), "Invalid format of property name.");
            }
            else if (token is JArray array)
            {
                foreach (var arrayObject in array)
                {
                    AssertCamelCaseJson(arrayObject);
                }
            }
        }

        // TODO: add tests
    }
}