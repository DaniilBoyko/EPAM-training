using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank.Models.Interfaces
{
    public interface IFileWorker
    {
        List<Account> LoadAccountsFromFile(string path);
        void SaveAccountsToFile(List<Account> books, string path);
    }
}
