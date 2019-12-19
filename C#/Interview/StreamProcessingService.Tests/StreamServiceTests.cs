using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InterviewAssignments.StreamProcessingService.Tests
{
    [TestClass]
    public class StreamServiceTests
    {
        private const double _equalityThreshold = 1e-8;

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            const double expectedResult = 3.5285714285d;

            var dataStreams = new List<IList<double>>
            {
                new List<double> {12, 2.2, 1.1},
                new List<double> {3.4, 5, 1, 0}
            };

            var service = StreamServiceFactory.CreateService();

            // Act

            var result = service.CalculateAverage(dataStreams);

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange

            const double expectedResult = 3.5285714285d;

            var service = StreamServiceFactory.CreateService();

            var data1 = new MemoryStream(Encoding.UTF8.GetBytes("12;2.2\nppp\n\n\n1.1\n3.4;;"));
            var data2 = new MemoryStream(Encoding.UTF8.GetBytes("5;1\n\n;;0;"));

            var dataStreams = new List<Stream> { data1, data2 };

            // Act

            var result = service.CalculateAverageAsync(dataStreams).Result;

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange

            const double expectedResult = 3.5285714285d;

            var service = StreamServiceFactory.CreateService();

            var data = new List<double> { 12, 2.2, 1.1, 3.4, 5, 1, 0 };

            // Act

            var result = service.CalculateAverage(data, 4, d => d);

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange

            var service = StreamServiceFactory.CreateService();

            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(" 1 \t \npp\n3\n5\n7 \n9"));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(" 2 \t\t\npp\n4\n6\n8 \n10"));

            // Act

            var result = service.JoinAndSort(stream1, stream2).ToList();

            // Assert

            foreach (var i in Enumerable.Range(1, 10))
            {
                Assert.AreEqual(i, result[i - 1]);
            }
        }

        [TestMethod]
        // TODO: rename all tests
        public void TestMethod5()
        {
            // Arrange

            var service = StreamServiceFactory.CreateService();

            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(""));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(" 2 \t\t\npp\n4\n6\n8 \n10"));

            // Act

            var result = service.JoinAndSort(stream1, stream2).ToList();

            // Assert

            for (int i = 2, j = 0; i <= 10; i += 2, ++j)
            {
                Assert.AreEqual(i, result[j]);
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            // Arrange

            var service = StreamServiceFactory.CreateService();

            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(" 1 \t \npp\n3\n5\n7 \n9"));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(""));

            // Act

            var result = service.JoinAndSort(stream1, stream2).ToList();

            // Assert

            for (int i = 1, j = 0; i <= 10; i += 2, ++j)
            {
                Assert.AreEqual(i, result[j]);
            }
        }

        [TestMethod]
        public void TestMethod7()
        {
            // Arrange

            const double expectedResult = 4.675;
            const int numOfStreams = 1024;

            var service = StreamServiceFactory.CreateService();

            var data = new MemoryStream(Encoding.UTF8.GetBytes("12;2.2\nppp\n\n\n1.1\n3.4;;"));

            var dataStreams = new List<Stream>(Enumerable.Repeat(data, numOfStreams));

            // Act

            var result = service.CalculateAverageAsync(dataStreams).Result;

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethod8()
        {
            // Arrange

            const double expectedResult = double.NaN;

            var service = StreamServiceFactory.CreateService();

            var dataStreams = new List<Stream>();

            // Act

            var result = service.CalculateAverageAsync(dataStreams).Result;

            // Assert

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestMethod9()
        {
            // Arrange
            const int count = 1_000_000;
            var extractor = new Func<int, double>(d => d * 2.0);

            double expectedResult = Enumerable.Range(1, count).Select(extractor).Sum() / count;

            var service = StreamServiceFactory.CreateService();

            var data = Enumerable.Range(1, count).ToList();

            // Act

            var result = service.CalculateAverage(data, 4, d => d * 2);

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethodA()
        {
            // Arrange

            double expectedResult = double.PositiveInfinity;

            var service = StreamServiceFactory.CreateService();

            var data = new double[] { double.MaxValue, double.MaxValue };

            // Act

            var result = service.CalculateAverage(data, 4, d => d);

            // Assert

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestMethodB()
        {
            // Arrange

            double expectedResult = (double.MaxValue + double.MinValue) / 2;

            var service = StreamServiceFactory.CreateService();

            var data = new double[] { double.MaxValue, double.MinValue };

            // Act

            var result = service.CalculateAverage(data, 4, d => d);

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethodC()
        {
            // Arrange
            const int listCnt = 1024;
            const int itemsCnt = 1_000;
            const double expectedResult =1d;

            var dataStreams = Enumerable.Repeat(Enumerable.Repeat(1.0, itemsCnt).ToList(), listCnt).ToList();

            var service = StreamServiceFactory.CreateService();

            // Act

            var result = service.CalculateAverage(dataStreams);

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        [TestMethod]
        public void TestMethodD()
        {
            // Arrange

            var service = StreamServiceFactory.CreateService();

            // Act

            // ..

            // Assert

            Assert.ThrowsException<ArgumentNullException>(() => service.CalculateAverage(null));
        }

        [TestMethod]
        public void TestMethodE()
        {
            // Arrange

            var service = StreamServiceFactory.CreateService();

            var data1 = new MemoryStream(Encoding.UTF8.GetBytes("12;2.2\nppp\n\n\n1.1\n3.4;;"));

            var dataStreams = new List<Stream> { data1, null };

            // Act

            // ..

            // Assert

            Assert.ThrowsExceptionAsync<NullReferenceException>(() => service.CalculateAverageAsync(dataStreams));
        }

        [TestMethod]
        public void TestMethodF()
        {
            // Arrange

            const double expectedResult = 5.1d;

            var dataStreams = new List<IList<double>>
            {
                new List<double> {12, 2.2, 1.1},
                new List<double> {}
            };

            var service = StreamServiceFactory.CreateService();

            // Act

            var result = service.CalculateAverage(dataStreams);

            // Assert

            Assert.AreEqual(expectedResult, result, _equalityThreshold);
        }

        // TODO: more ordered tests
    }
}