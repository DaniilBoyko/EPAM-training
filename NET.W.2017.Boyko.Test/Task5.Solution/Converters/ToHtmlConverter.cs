using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converters
{
    public class ToHtmlConverter : Converter
    {
        public override string ConvertHyperlink(Hyperlink hyperlink)
        {
            return "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>";
        }

        public override string ConvertPlainText(PlainText plainText)
        {
            return plainText.Text;
        }

        public override string ConvertBoldText(BoldText boldText)
        {
            return "<b>" + boldText.Text + "</b>";
        }
    }
}
