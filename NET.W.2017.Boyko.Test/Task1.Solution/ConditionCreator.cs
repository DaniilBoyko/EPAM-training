using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    /// <summary>
    /// Model for create conditions
    /// </summary>
    public sealed class ConditionCreator
    {
        Func<string, Tuple<bool, string>> _conditions;

        /// <summary>
        /// Add condition.
        /// </summary>
        /// <param name="predicate">predicate for check message</param>
        /// <param name="message">error message if predicate return false</param>
        public void AddConditions(Predicate<string> predicate, string message)
        {
            _conditions += delegate(string mes)
            {
                if (predicate(mes))
                {
                    return new Tuple<bool, string>(false, message);
                }
                else
                {
                    return new Tuple<bool, string>(true, "");
                }
            };
        }

        /// <summary>
        /// Return all conditions wich we built.
        /// </summary>
        /// <returns>Func wich get string and return tuple of bool and string</returns>
        public Func<string, Tuple<bool, string>> GetConditions()
        {
            return _conditions;
        }

    }
}
