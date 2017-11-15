using System;

namespace Watch.Models
{
    /// <summary>
    /// Model of person with listen abilities.
    /// </summary>
    public class Person : NotifyAny
    {
        /// <summary>
        /// Call when anyone notify person.
        /// </summary>
        /// <param name="sender">sender of notify</param>
        /// <param name="timeLeftEventArgs">arguments of the notify</param>
        protected override void Notify(object sender, TimeLeftEventArgs timeLeftEventArgs)
        {
            Console.Write("Person notify:");
            Console.WriteLine(timeLeftEventArgs.Message);
        }
    }
}
