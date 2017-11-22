using System;
using BLL.Interfaces;

namespace BLL.Models
{
    /// <summary>
    /// Class for generate id.
    /// </summary>
    public class GenerateId : IGenerateId
    {
        /// <summary>
        /// Generate id.
        /// </summary>
        /// <returns>Generating id.</returns>
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
