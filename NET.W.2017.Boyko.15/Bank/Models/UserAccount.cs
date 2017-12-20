using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Bank.Infrastructure.Attributes;

namespace Bank.Models
{
    public class UserAccount
    {
        public static IEnumerable<AccountType> AccountType = new List<AccountType>
        {
            new AccountType{ Id = 1 , Name = "Base"},
            new AccountType{ Id = 2 , Name = "Gold"},
            new AccountType{ Id = 3 , Name = "Platinum"},
        };

        [Required(ErrorMessage ="Name is required.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 15 symbols.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Surname is required.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Login must be between 4 and 15 symbols.")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Type is required.")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [PositiveValue(ErrorMessage ="Amount must be greater than 0 or equal.")]
        public double Amount { get; set; }
    }
}