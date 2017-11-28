using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1.Console
{
    class Program
    {
        public static void ShowInfo(Tuple<bool, string> tuple)
        {
            System.Console.WriteLine("Password {0} is {1}/n", tuple.Item1, tuple.Item2);
        }

        static void Main(string[] args)
        {
          
            PasswordCheckerService passwordCheckerService = new PasswordCheckerService(new SqlRepository());
            try
            {
                ShowInfo(passwordCheckerService.VerifyPassword(null));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            ShowInfo(passwordCheckerService.VerifyPassword(String.Empty));
            ShowInfo(passwordCheckerService.VerifyPassword("123456"));
            ShowInfo(passwordCheckerService.VerifyPassword("123456789012345678"));
            ShowInfo(passwordCheckerService.VerifyPassword("12345678"));
            ShowInfo(passwordCheckerService.VerifyPassword("abcdefasd"));
            ShowInfo(passwordCheckerService.VerifyPassword("abcdefasd1"));
        }
    }
}
