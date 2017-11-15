using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch
{
    public class Computer : NotifyAny
    {
        protected override void Notify(Object sender, TimeLeftEventArgs timeLeftEventArgs)
        {
            Console.WriteLine("Computer notify:");
            Console.WriteLine(timeLeftEventArgs.Message);
        }
    }
}
