using Task5.Solution.DocumentParts;

namespace Task5.Solution.Converters
{
    /// <summary>
    /// Convert document part to news
    /// </summary>
    public abstract class Converter
    {
        /// <summary>
        /// Convert hyper link to text.
        /// </summary>
        /// <param name="hyperlink">hyper link</param>
        /// <returns>string</returns>
        public abstract string ConvertHyperlink(Hyperlink hyperlink);

        /// <summary>
        /// Convrt plain text to some text.
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <returns>string</returns>
        public abstract string ConvertPlainText(PlainText plainText);

        /// <summary>
        /// Convrt bold text to some text.
        /// </summary>
        /// <param name="boldText">bold text</param>
        /// <returns>string</returns>
        public abstract string ConvertBoldText(BoldText boldText);

        /// <summary>
        /// Covert document part.
        /// </summary>
        /// <param name="documentPart">document part</param>
        public string Convert(DocumentPart documentPart)
        {
            if (documentPart.GetType() == typeof(Hyperlink))
            {
                return $"{ConvertHyperlink((Hyperlink) documentPart)}\n";
            }
            if (documentPart.GetType() == typeof(PlainText))
            {
                return $"{ConvertPlainText((PlainText) documentPart)}\n";
            }

            if (documentPart.GetType() == typeof(BoldText))
            {
                return $"{ConvertBoldText((BoldText) documentPart)}\n";
            }

            return "";
        }
    }
}
