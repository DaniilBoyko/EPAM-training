using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Surname is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Type is required.")]
        public string Type { get; set; }

        public double Amount { get; set; }
    }
}