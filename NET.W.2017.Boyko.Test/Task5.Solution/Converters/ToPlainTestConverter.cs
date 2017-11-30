using Task5.Solution.DocumentParts;

namespace Task5.Solution.Converters
{
    /// <summary>
    /// Convert document part to plain text.
    /// </summary>
    public class ToPlainTestConverter : Converter
    {
        /// <inheritdoc></inheritdoc>
        public override string ConvertHyperlink(Hyperlink hyperlink)
        {
            return hyperlink.Text + " [" + hyperlink.Url + "]";
        }

        /// <inheritdoc></inheritdoc>
        public override string ConvertPlainText(PlainText plainText)
        {
            return plainText.Text;
        }

        /// <inheritdoc></inheritdoc>
        public override string ConvertBoldText(BoldText boldText)
        {
            return "**" + boldText.Text + "**";
        }
    }
}
