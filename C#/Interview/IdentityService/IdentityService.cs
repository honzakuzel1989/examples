using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using InterviewAssignments.IdentityService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SecurityDriven.Inferno;
using SecurityDriven.Inferno.Extensions;
using SecurityDriven.Inferno.Hash;

namespace InterviewAssignments.IdentityService
{
    class IdentityService : IIdentityService
    {
        //
        // TODO: not very SOLID service, especially SRP (encrypt/decrypt, save/load, register, authenticate/register...). Refactoring!
        //

        // Master password - shared secret in service
        // INFO: it is possible to set key from some 'secure' type of channel, like network, ssh, ... and shared between the services with json
        public readonly byte[] masterKey = Utils.SafeUTF8.GetBytes("password");

        // User data storage 
        // INFO: ConcurrentDictionary for parallel approach
        private readonly ConcurrentDictionary<string, UserData> usersData = new ConcurrentDictionary<string, UserData>();

        /// <summary>
        /// Create new service based on json file
        /// </summary>
        public IdentityService(string pathToJsonFile)
        {
            // Load from file
            LoadFromJson(pathToJsonFile);
        }

        /// <summary>
        /// Create new service based on memory
        /// </summary>
        public IdentityService(IEnumerable<(string user, string password)> data)
        {
            // Load from data structure
            foreach (var (user, password) in data)
                Register(user, password);
        }

        public AuthenticationResult Authenticate(string userName, string password)
        {
            // Encrypt login case insensitive
            var login = userName.ToLower();

            // Try get user
            if (usersData.TryGetValue(login, out var userData))
            {
                // Check password hash
                if (Hash(password) == userData.Password)
                {
                    // Get user data
                    return AuthenticationResult.Successful(Decrypt(userData.UserName), userData.Properties);
                }

                // Invalid pass
                return AuthenticationResult.Failed(AuthenticationError.InvalidPassword);
            }

            // User not found
            return AuthenticationResult.Failed(AuthenticationError.UserNotFound);
        }

        public RegistrationResult Register(string userName, string password, IDictionary<string, string> properties = null)
        {
            // Check user param
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException(nameof(userName));

            // Check pass param
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException(nameof(password));

            // CaseInsensitive login
            var login = userName.ToLower();

            // Check user
            if (usersData.ContainsKey(login))
                return RegistrationResult.Failed(RegistrationError.UserAlreadyExists);

            // Create new record
            AddNew(login, Encrypt(userName), Hash(password), properties);

            // Ok
            return RegistrationResult.Successful();
        }

        private void AddNew(string login, string encryptedUserName, string hashedPassword, IDictionary<string, string> properties = null)
        {
            // Case-insensitive login and case sensitive data
            usersData[login] = new UserData(Encrypt(login), encryptedUserName, hashedPassword,
                // with or without properties
                properties ?? new Dictionary<string, string>());
        }

        private string Hash(string str)
        {
            // Make SHA384 hash
            using (var ha = SuiteB.HashFactory())
            {
                // Compute
                var hashBytes = ha.ComputeHash(Utils.SafeUTF8.GetBytes(str));
                // String from hash
                return hashBytes.ToBase16();
            }
        }

        private string Encrypt(string str)
        {
            // Encrypt
            var encryptedBytes = SuiteB.Encrypt(masterKey, new ArraySegment<byte>(Utils.SafeUTF8.GetBytes(str)));
            return encryptedBytes.ToBase16();
        }

        private string Decrypt(string str)
        {
            // Decrypt
            var dencryptedBytes = SuiteB.Decrypt(masterKey, new ArraySegment<byte>(str.FromBase16()));
            return Utils.SafeUTF8.GetString(dencryptedBytes);
        }

        // JSON Settings
        readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
        };

        public void SaveToJson(string pathToJsonFile, bool overwrite = false)
        {
            // Cannot override existing file
            if (!overwrite && File.Exists(pathToJsonFile))
                throw new ArgumentException($"Cannot override existing file {pathToJsonFile}");

            // Open and overwrite or create file in UTF8
            using (var writter = File.CreateText(pathToJsonFile))
            {
                // Create and use JSON serializer (save without properties)
                JsonSerializer.Create(settings).Serialize(writter, usersData.Values);
            }
        }

        private void LoadFromJson(string pathToJsonFile)
        {
            // Open file for read in UTF8
            using (var reader = new JsonTextReader(File.OpenText(pathToJsonFile)))
            {
                // Create and use JSON serializer
                var result = JsonSerializer.Create(settings).Deserialize<UserData[]>(reader);

                // Add data
                foreach (var item in result)
                    AddNew(Decrypt(item.Login), item.UserName, item.Password, item.Properties);
            }
        }
    }
}