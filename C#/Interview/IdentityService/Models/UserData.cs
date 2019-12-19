using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace InterviewAssignments.IdentityService.Models
{
    class UserData
    {
        // Props

        /// <summary>
        /// Not encrypted properties - villain can set or unset properties in JSON
        /// INFO: it is possible encrypt whole file, of course
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }

        // Login data

        /// <summary>
        /// Encrypted login (case insensitive for index to dictionary)
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Encrypted original user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Hashed password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Default empty ctor
        /// </summary>
        public UserData()
        {

        }

        /// <summary>
        /// Create new stored data for user
        /// </summary>
        public UserData(string login, string userName, string password)
        {
            Login = login;
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Create new data for user
        /// </summary>
        public UserData(string login, string userName, string password, IDictionary<string, string> properties)
            : this(login, userName, password)
        {
            Properties = properties;
        }
    }
}
