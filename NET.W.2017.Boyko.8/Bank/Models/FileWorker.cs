using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models.Interfaces;

namespace Bank.Models
{
    public class FileWorker : IFileWorker
    {
        #region Public

        #region public Interface Methods

        /// <summary>
        /// Read accounts from file.
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>List of accounts.</returns>
        public List<Account> LoadAccountsFromFile(string path)
        {
            var accounts = new List<Account>();

            using (var binReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (binReader.PeekChar() > -1)
                {

                }
            }

            return accounts;
        }

        /// <summary>
        /// Writle list of accounts to file.
        /// </summary>
        /// <param name="accounts">list of books</param>
        /// <param name="path">path to file</param>
        public void SaveAccountsToFile(List<Account> accounts, string path)
        {
            if (accounts == null)
                throw new ArgumentNullException(nameof(accounts));

            using (BinaryWriter binWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Account account in accounts)
                {
                }
            }
        }

        #endregion public Interface Methods

        #endregion Public
    }
}
