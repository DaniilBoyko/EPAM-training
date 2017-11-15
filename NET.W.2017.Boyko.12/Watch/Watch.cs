using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Watch
{
    public class Watch
    {
        private long seconds;
        private Thread thread;
        private long Seconds
        {
            get => seconds;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Seconds can't be less then one");
                }
                   
                seconds = value;
            }
        }

        public delegate void TimeLeftEventHandler(object sender, TimeLeftEventArgs e);

        public event TimeLeftEventHandler TimeLeft;

        protected virtual void OnTimeLeft(TimeLeftEventArgs e)
        {
            TimeLeft?.Invoke(this, e);
        }

        public Watch(long seconds)
        {
            Seconds = seconds;
        }

        public void SetSeconds(int sec)
        {
            thread?.Abort();
            Seconds = sec;
        }

        public void Start()
        {
            thread = new Thread(() => Run(this));
            thread.Start();
        }

        private static void Run(Watch watch)
        {
            Thread.Sleep((int)watch.Seconds * 1000);
            watch.OnTimeLeft(new TimeLeftEventArgs("Time is LEFTTTT!!!"));
        }
    }
}
