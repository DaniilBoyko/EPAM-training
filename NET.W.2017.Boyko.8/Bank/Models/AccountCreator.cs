﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models.Accounts;
using Bank.Models.Exceptions;

namespace Bank.Models
{
    static class AccountCreator
    {
        public enum AccountType { Base, Gold, Platinum }

        /// <summary>
        /// Create an instance of account
        /// </summary>
        /// <param name="accountType">type of account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start amount of money on account</param>
        /// <returns>An instance of account.</returns>
        public static Account CreateAccount(AccountType accountType, string name, string surname, double amount = 0)
        {
            switch (accountType)
            {
                case AccountType.Base: return new BaseAccount(name, surname, amount);
                case AccountType.Gold: return new GoldAccount(name, surname, amount);
                case AccountType.Platinum: return new PlatinumAccount(name, surname, amount);
                default: throw new UnknownAccountTypeException("Unknown account type");
            }
        }
    }
}
