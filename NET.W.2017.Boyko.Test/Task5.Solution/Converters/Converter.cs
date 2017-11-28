namespace Task5.Solution.Converters
{
    public abstract class Converter
    {
        public abstract string ConvertHyperlink(Hyperlink documentPart);
        public abstract string ConvertPlainText(PlainText documentPart);
        public abstract string ConvertBoldText(BoldText document);

        public string CollectionInformation { get; set; } = "";

        public void Convert(DocumentPart documentPart)
        {
            if (documentPart.GetType() == typeof(Hyperlink))
            {
                CollectionInformation += $"{ConvertHyperlink((Hyperlink) documentPart)}\n";
            }
            if (documentPart.GetType() == typeof(PlainText))
            {
                CollectionInformation += $"{ConvertPlainText((PlainText) documentPart)}\n";
            }

            if (documentPart.GetType() == typeof(BoldText))
            {
                CollectionInformation += $"{ConvertBoldText((BoldText) documentPart)}\n";
            }
        }
    }
}
