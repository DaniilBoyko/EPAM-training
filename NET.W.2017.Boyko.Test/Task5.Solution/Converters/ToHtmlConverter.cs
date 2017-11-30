using Task5.Solution.DocumentParts;

namespace Task5.Solution.Converters
{
    /// <summary>
    /// Convert document model to string.
    /// </summary>
    public class ToHtmlConverter : Converter
    {
        /// <inheritdoc></inheritdoc>
        public override string ConvertHyperlink(Hyperlink hyperlink)
        {
            return "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>";
        }

        /// <inheritdoc></inheritdoc>
        public override string ConvertPlainText(PlainText plainText)
        {
            return plainText.Text;
        }

        /// <inheritdoc></inheritdoc>
        public override string ConvertBoldText(BoldText boldText)
        {
            return "<b>" + boldText.Text + "</b>";
        }
    }
}
