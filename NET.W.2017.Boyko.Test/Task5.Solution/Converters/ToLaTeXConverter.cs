using Task5.Solution.DocumentParts;

namespace Task5.Solution.Converters
{
    /// <summary>
    /// Convert document part to hyper link.
    /// </summary>
    public class ToLaTeXConverter : Converter
    {
        /// <inheritdoc></inheritdoc>
        public override string ConvertHyperlink(Hyperlink hyperlink)
        {
            return "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}";
        }

        /// <inheritdoc></inheritdoc>
        public override string ConvertPlainText(PlainText plainText)
        {
            return plainText.Text;
        }

        /// <inheritdoc></inheritdoc>
        public override string ConvertBoldText(BoldText boldText)
        {
            return "\\textbf{" + boldText.Text + "}";
        }
    }
}
