using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Bank.Models.Interfaces;
using Bank.Models.Accounts;

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
                    int size = binReader.ReadInt32();
                    byte[] byteArray = binReader.ReadBytes(size);
                    Account account = ByteArrayToAccount(byteArray);
                    accounts.Add(account);
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
                    byte[] byteArray = AccountToByteArray(account);
                    binWriter.Write(byteArray.Length);
                    binWriter.Write(byteArray);
                }
            }
        }

        #endregion public Interface Methods

        #endregion Public

        #region Private

        private byte[] AccountToByteArray(Account account)
        {
            if (account == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, account);

            return ms.ToArray();
        }

        private Account ByteArrayToAccount(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Account account = (Account)binForm.Deserialize(memStream);

            return account;
        }

        #endregion Private
    }
}
