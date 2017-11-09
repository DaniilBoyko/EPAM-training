//// <copyright file="BankStorage.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Accounts;
    using Interfaces;

    /// <summary>
    /// Implementation of IFileWorker for work with file.
    /// </summary>
    public class BankStorage : IBankStorage
    {
        #region Public

        #region public Interface Methods

        /// <summary>
        /// Read accounts from file.
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>List of accounts.</returns>
        public IEnumerable<Account> LoadAccounts(string path)
        {
            var accounts = new List<Account>();

            using (var binReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (binReader.PeekChar() > -1)
                {
                    int size = binReader.ReadInt32();
                    byte[] byteArray = binReader.ReadBytes(size);
                    Account account = this.ByteArrayToAccount(byteArray);
                    accounts.Add(account);
                }
            }

            return accounts;
        }

        /// <summary>
        /// Write list of accounts to file.
        /// </summary>
        /// <param name="accounts">list of books</param>
        /// <param name="path">path to file</param>
        public void SaveAccounts(IEnumerable<Account> accounts, string path)
        {
            if (accounts == null)
            { 
                throw new ArgumentNullException(nameof(accounts));
            }

            using (BinaryWriter binWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Account account in accounts)
                {
                    byte[] byteArray = this.AccountToByteArray(account);
                    binWriter.Write(byteArray.Length);
                    binWriter.Write(byteArray);
                }
            }
        }

        #endregion public Interface Methods

        #endregion Public

        #region Private

        /// <summary>
        /// Convert account to byte array.
        /// </summary>
        /// <param name="account">converting account</param>
        /// <returns>The array of bytes.</returns>
        private byte[] AccountToByteArray(Account account)
        {
            if (account == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, account);

            return ms.ToArray();
        }

        /// <summary>
        /// Convert byte array to account.
        /// </summary>
        /// <param name="arrBytes">array of bytes</param>
        /// <returns>Converting account.</returns>
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
