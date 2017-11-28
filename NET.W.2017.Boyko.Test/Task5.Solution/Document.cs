﻿using System;
using System.Collections.Generic;
using Task5.Solution.Converters;

namespace Task5.Solution
{
    public class Document
    {
        private List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public string Convert(Converter converter)
        {
            string output = string.Empty;

            foreach (DocumentPart part in this.parts)
            {
                output += $"{converter.Convert(part)}\n";
            }

            return output;
        }
    }
}
