using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace BLL.Tests.Fakes
{
    public class GenerateIdEasy : IGenerateId
    {
        private static int _current = 0;

        public string Generate()
        {
            _current++;
            return _current.ToString();
        }
    }
}
