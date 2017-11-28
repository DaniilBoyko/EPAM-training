using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace URL_Parser.Interfaces
{
    public abstract class Parser
    {
        Parser NextParser { get; set; }

        public abstract void Parse(string info, XElement element);

        private void CallNextParser(string info, XElement element)
        {
            NextParser?.Parse(info, element);
        }
    }
}
