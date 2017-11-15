using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch
{
    public abstract class NotifyAny
    {
        protected abstract void Notify(Object sender, TimeLeftEventArgs timeLeftEventArgs);

        public void Register(Watch watch)
        {
            watch.TimeLeft += Notify;
        }

        public void Unregister(Watch watch)
        {
            watch.TimeLeft -= Notify;
        }
    }
}
