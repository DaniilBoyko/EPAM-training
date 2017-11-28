namespace Task5.Solution.Converters
{
    public abstract class Converter
    {
        public abstract string ConvertHyperlink(Hyperlink documentPart);
        public abstract string ConvertPlainText(PlainText documentPart);
        public abstract string ConvertBoldText(BoldText document);

        public string Convert(DocumentPart documentPart)
        {
            if (documentPart.GetType() == typeof(Hyperlink))
            {
                return ConvertHyperlink((Hyperlink) documentPart);
            }
            if (documentPart.GetType() == typeof(PlainText))
            {
                return ConvertPlainText((PlainText) documentPart);
            }

            if (documentPart.GetType() == typeof(BoldText))
            {
                return ConvertBoldText((BoldText) documentPart);
            }
            return null;
        }
    }
}
