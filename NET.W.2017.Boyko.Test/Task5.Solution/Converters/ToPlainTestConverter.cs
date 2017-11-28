using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converters
{
    public class ToPlainTestConverter : Converter
    {
        public override string ConvertHyperlink(Hyperlink hyperlink)
        {
            return hyperlink.Text + " [" + hyperlink.Url + "]";
        }

        public override string ConvertPlainText(PlainText plainText)
        {
            return plainText.Text;
        }

        public override string ConvertBoldText(BoldText boldText)
        {
            return "**" + boldText.Text + "**";
        }
    }
}
