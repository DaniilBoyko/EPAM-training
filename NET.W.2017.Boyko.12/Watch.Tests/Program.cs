using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Watch;

namespace Watch.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Watch watch = new Watch(5);
            Person person = new Person();
            Computer computer = new Computer();
            person.Register(watch);
            computer.Register(watch);

            watch.Start();

            Console.WriteLine("Do some calculations");
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine(i);      
                Thread.Sleep(300);
            }
        }
    }
}
