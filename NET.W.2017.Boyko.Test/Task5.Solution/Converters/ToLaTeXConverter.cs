using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converters
{
    public class ToLaTeXConverter : Converter
    {
        public override string ConvertHyperlink(Hyperlink hyperlink)
        {
            return "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}";
        }

        public override string ConvertPlainText(PlainText plainText)
        {
            return plainText.Text;
        }

        public override string ConvertBoldText(BoldText boldText)
        {
            return "\\textbf{" + boldText.Text + "}";
        }
    }
}
