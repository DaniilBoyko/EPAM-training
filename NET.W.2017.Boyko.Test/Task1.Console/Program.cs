using System;
using System.Linq;
using Task1.Solution;


namespace Task1.Console
{
    class Program
    {
        public static void ShowInfo(Tuple<bool, string> tuple)
        {
            System.Console.WriteLine("Password {0}. {1}/n", tuple.Item1, tuple.Item2);
        }

        static void Main()
        {
            PasswordCheckerService passwordCheckerService = new PasswordCheckerService(new SqlRepository());
            ConditionCreator conditionCreator = new ConditionCreator();
            conditionCreator.AddConditions(str => str == string.Empty, "Password is empty");
            conditionCreator.AddConditions(str => str.Length <= 7, "Password length too short");
            conditionCreator.AddConditions(str => str.Length >= 15, "Password length too long");
            conditionCreator.AddConditions(str => !str.Any(char.IsLetter), "Password hasn't alphanumerical chars");
            conditionCreator.AddConditions(str => !str.Any(char.IsNumber), "Password hasn't digits");
            try
            {
                ShowInfo(passwordCheckerService.VerifyPassword(conditionCreator.GetConditions(), "12345678a"));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
