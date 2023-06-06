using System;
using System.IO;

namespace CBALoginChecker
{
    public class LoginVerifier
    {
        public string LoginFilePath { get; set; }

        public LoginVerifier() { }

        public LoginVerifier(string filePath) 
        {
            LoginFilePath = filePath;
        }

        public bool IsLoginValid(string username, string password)
        {
            bool unameReadFromFile = false;            

            try
            {
                if (string.IsNullOrEmpty(LoginFilePath))
                {
                    throw new Exception("Login file path is undefined. Please set the \"LoginFilePath\" property.");
                }

                using (StreamReader reader = new StreamReader(LoginFilePath))
                {
                    string fileData;
                    while ((fileData = reader.ReadLine()) != null)
                    {
                        if (!unameReadFromFile)
                        {
                            if (fileData.ToLower() != username.ToLower())
                            {
                                // the username doesn't match so login failed
                                return false;
                            }
                            unameReadFromFile = true;
                            continue;
                        }

                        if (fileData != password)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
