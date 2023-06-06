using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBALoginChecker
{
    public class LoginVerifier
    {
        public bool IsLoginValid(string username, string password)
        {
            bool unameReadFromFile = false;
            string fileName = @"e:\loginfile.txt";

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!unameReadFromFile)
                        {
                            if (line.ToLower() != username.ToLower())
                            {
                                // the username doesn't match so login failed
                                return false;
                            }
                            unameReadFromFile = true;
                            continue;
                        }

                        if (line != password)
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
