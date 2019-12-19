using System;
using System.Collections.Generic;

namespace InterviewAssignments.IdentityService.Models
{
    public class AuthenticationResult
    {
        private AuthenticationResult(bool isSuccessful, AuthenticationError? error = null, string originalUserName = null, IDictionary<string, string> properties = null)
        {
            IsSuccessful = isSuccessful;
            Error = error;
            OriginalUserName = originalUserName;
            Properties = properties;
        }

        public bool IsSuccessful { get; }
        public IDictionary<string, string> Properties { get; }
        public AuthenticationError? Error { get; }
        public string OriginalUserName { get; }

        public static AuthenticationResult Successful(string originalUserName, IDictionary<string, string> properties)
        {
            if (originalUserName is null)
            {
                throw new ArgumentNullException(nameof(originalUserName));
            }

            if (properties is null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            return new AuthenticationResult(true, null, originalUserName, properties);
        }

        public static AuthenticationResult Failed(AuthenticationError error) => new AuthenticationResult(false, error);
    }
}