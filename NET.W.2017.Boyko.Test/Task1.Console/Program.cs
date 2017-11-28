using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;


namespace Task1.Console
{
    class Program
    {

        public static CheckCondition CreateOwnCheckCondition()
        {
            CheckCondition first = new CheckCondition(pas => pas == null, pas => throw new ArgumentException($"{pas} is null arg"));
            CheckCondition second = new CheckCondition(pas => pas == string.Empty, pas => Tuple.Create(false, $"{pas} is empty "));
            first.SetNextCheckCondition(second);
            second.SetNextCheckCondition(new CheckCondition(pas => pas.Length <= 7, pas => Tuple.Create(false, $"{pas} length too short")));

            return first;
        }

        public static void ShowInfo(Tuple<bool, string> tuple)
        {
            System.Console.WriteLine("Password {0} is {1}/n", tuple.Item1, tuple.Item2);
        }

        static void Main(string[] args)
        {
          
            PasswordCheckerService passwordCheckerService = new PasswordCheckerService(new SqlRepository());
            try
            {
                ShowInfo(passwordCheckerService.VerifyPassword(CreateOwnCheckCondition(), string.Empty));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }
    }
}
