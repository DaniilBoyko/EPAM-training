using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch
{
    public class TimeLeftEventArgs : EventArgs
    {
        public string Message { get; set; }

        public TimeLeftEventArgs(string message)
        {
            Message = message;
        }
    }
}
