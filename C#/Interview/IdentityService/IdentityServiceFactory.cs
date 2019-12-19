using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InterviewAssignments.IdentityService
{
    public static class IdentityServiceFactory
    {
        public static IIdentityService CreateFromJson(string pathToJsonFile)
        {
            // Check param
            if (string.IsNullOrEmpty(pathToJsonFile))
                throw new ArgumentException(nameof(pathToJsonFile));

            // Check file
            if (!File.Exists(pathToJsonFile))
                throw new FileNotFoundException(pathToJsonFile);

            // Create a new service
            return new IdentityService(pathToJsonFile);
        }

        public static IIdentityService CreateFromMemory(IEnumerable<string> users, IEnumerable<string> passwords)
        {
            // Check users
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            // Check passwords
            if (passwords == null)
                throw new ArgumentNullException(nameof(passwords));

            // Check lengths
            if (passwords.Count() != users.Count())
                throw new ArgumentException($"length of {nameof(passwords)} is not same like length of {nameof(users)}");

            // Create a new service
            return new IdentityService(users.Zip(passwords, (user, pass) => (user, pass)));
        }
    }
}