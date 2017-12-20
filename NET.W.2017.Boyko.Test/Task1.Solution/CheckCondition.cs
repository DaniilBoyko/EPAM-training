using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class CheckCondition
    {
        private Predicate<string> predicate;
        private Func<string, Tuple<bool, string>> verify;
        private CheckCondition nextCheckCondition = null;

        public CheckCondition(Predicate<string> predicate, Func<string, Tuple<bool, string>> verify)
        {
            this.predicate = predicate;
            this.verify = verify;
        }

        public void SetNextCheckCondition(CheckCondition checkCondition)
        {
            nextCheckCondition = checkCondition;
        }

        public Tuple<bool, string> Check(string password)
        {
            if (predicate(password))
                return verify(password);

            return nextCheckCondition?.Check(password);
        }
    }
}
