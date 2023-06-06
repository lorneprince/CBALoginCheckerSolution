using System;

namespace CBALoginChecker
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var loginVerifierObj = new LoginVerifier(@"e:\loginfile.txt");

                Console.Write("Please enter your username: ");
                var uname = Console.ReadLine();

                Console.Write("\n\n");

                Console.Write("Please enter your password: ");
                var pwd = Console.ReadLine();

                if(loginVerifierObj.IsLoginValid(uname, pwd))
                {
                    Console.WriteLine("\n\n\nCongratulations, you are now logged in.");
                }
                else
                {
                    Console.WriteLine("\n\n\nSorry, your login information is invalid. Please try again");
                }
                Console.ReadLine();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
