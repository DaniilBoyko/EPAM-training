using System;
using System.Linq;
using Task1.Solution;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IRepository repository;

        public PasswordCheckerService(IRepository repository)
        {
            this.repository = repository;
        }

        public Tuple<bool, string> VerifyPassword(CheckCondition checkCondition, string password)
        {
            return checkCondition.Check(password);
        }
    }
}
