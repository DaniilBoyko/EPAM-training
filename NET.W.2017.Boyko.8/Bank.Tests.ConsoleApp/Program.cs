using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Bank.Tests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "BankAccountsStorage.txt";
                Models.FileWorker fileWorker = new Models.FileWorker();
                Models.BankService bankService = new Models.BankService(fileWorker);
                //bankService.CreateNewAccount(Models.AccountCreator.AccountType.Gold, "Pit", "Marlow", 231.3);
                //bankService.CreateNewAccount(Models.AccountCreator.AccountType.Gold, "Kate", "Marlow", 2321);
                //bankService.ShowCurrentAccountInfo();
                bankService.LoadAccountsFromFile(path);


                Console.WriteLine("CREATE NEW ACCOUNT:\n");
                bankService.CreateNewAccount(Models.AccountCreator.AccountType.Base, "Daniil", "Boyko");
                bankService.ShowCurrentAccountInfo();

                Console.WriteLine("DEPOSIT TO ACCOUNT:\n");
                bankService.DepositToCurrentAccount(900.3);
                bankService.ShowCurrentAccountInfo();

                Console.WriteLine("WITHDRAW FROM ACCOUNT:\n");
                bankService.WithdrawFromCurrentAccount(600.3);
                bankService.ShowCurrentAccountInfo();

                Console.WriteLine("CLOSE ACCOUNT:\n");
                bankService.WithdrawFromCurrentAccount(300);
                bankService.CloseCurrentAccount();

                Console.WriteLine("SAVE ACCOUNTS:\n");
                bankService.SaveAccountsToFile(path);

                Console.WriteLine("LOAD ACCOUNTS:\n");
                bankService.LoadAccountsFromFile(path);

                Console.WriteLine("OPEN ACCOUNT:\n");
                bankService.SelectCurrentAccount("246d065d-5728-486c-aa57-39cc43ee1f98", "Kate", "Marlow");
                bankService.ShowCurrentAccountInfo();
                bankService.DepositToCurrentAccount(100);
                bankService.WithdrawFromCurrentAccount(1000);
                bankService.ShowCurrentAccountInfo();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
