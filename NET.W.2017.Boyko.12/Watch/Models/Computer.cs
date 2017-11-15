using System;

namespace Watch.Models
{
    /// <summary>
    /// Model of Computer with listen abilities.
    /// </summary>
    public class Computer : NotifyAny
    {
        /// <summary>
        /// Call when anyone notify computer.
        /// </summary>
        /// <param name="sender">sender of notify</param>
        /// <param name="timeLeftEventArgs">arguments of the notify</param>
        protected override void Notify(object sender, TimeLeftEventArgs timeLeftEventArgs)
        {
            Console.Write("Computer notify:");
            Console.WriteLine(timeLeftEventArgs.Message);
        }
    }
}
