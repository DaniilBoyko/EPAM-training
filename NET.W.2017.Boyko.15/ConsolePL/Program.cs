using System;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolverConsole();
        }

        public static void Main(string[] args)
        {
            var service = Resolver.Get<IAccountService>();

            try
            {
                Console.WriteLine("-----CREATE NEW ACCOUNT-----");
                service.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);
                service.ShowAccountInfo();

                Console.WriteLine("-----WITHDRAW 500 FROM ACCOUNT-----");
                service.WithdrawFromAccount(500);
                service.ShowAccountInfo();

                Console.WriteLine("-----DEPOSIT 100 TO THE ACCOUNT-----");
                service.DepositToAccount(100);
                service.ShowAccountInfo();

                Console.WriteLine("-----WITHDRAW 600 FROM ACCOUNT-----");
                service.WithdrawFromAccount(600);
                service.ShowAccountInfo();

                Console.WriteLine("-----DELETE ACCOUNT-----");
                service.DeleteAccount();

                Console.WriteLine("----SHOW CURRENT ACCOUNT INFO-----");
                service.ShowAccountInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
