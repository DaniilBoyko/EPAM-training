using System;
using System.Collections.Generic;
using Task5.Solution.Collectors;
using Task5.Solution.Converters;
using Task5.Solution.DocumentParts;

namespace Task5.Solution
{
    /// <summary>
    /// Model of document.
    /// </summary>
    public class Document
    {
        private readonly List<DocumentPart> _parts;

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="parts"></param>
        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this._parts = new List<DocumentPart>(parts);
        }

        /// <summary>
        /// Convert document to another type of text.
        /// </summary>
        /// <param name="converter">converter</param>
        /// <param name="collector">collect information</param>
        /// <returns></returns>
        public string Convert(Converter converter, Collector collector)
        {
            foreach (DocumentPart part in this._parts)
            {
                collector.Collect(converter.Convert(part));
            }

            return collector.GetInfo();
        }
    }
}
