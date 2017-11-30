using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Collectors
{
    /// <summary>
    /// Collect strings in one string.
    /// </summary>
    public abstract class Collector
    {
        private string _information = string.Empty;

        /// <summary>
        /// Collect information.
        /// </summary>
        /// <param name="info">adding informatioin</param>
        public virtual void Collect(string info)
        {
            _information += info ?? throw new ArgumentNullException(nameof(info));
        }

        /// <summary>
        /// Clear infromation in collector.
        /// </summary>
        public void Clear()
        {
            _information = string.Empty;
        }

        /// <summary>
        /// Get collection information.
        /// </summary>
        /// <returns>collection information</returns>
        public string GetInfo()
        {
            return _information;
        }
    }
}
