using System;
using System.Threading;
using Watch.Models;

namespace Watch.Tests
{
    /// <summary>
    /// Contains entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Watch watch = new Watch(5000);
            Person person = new Person();
            Computer computer = new Computer();
            person.Register(watch);
            computer.Register(watch);

            watch.Start();

            Console.WriteLine("Do some calculations");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);      
                Thread.Sleep(300);
            }
        }
    }
}
