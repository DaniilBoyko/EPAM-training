namespace Watch.Models
{
    /// <summary>
    /// Contains abilities of notify.
    /// </summary>
    public abstract class NotifyAny
    {
        /// <summary>
        /// Register in observable object.
        /// </summary>
        /// <param name="watch"></param>
        public void Register(Watch watch)
        {
            watch.TimeLeft += Notify;
        }

        /// <summary>
        /// Unregister in observable object.
        /// </summary>
        /// <param name="watch"></param>
        public void Unregister(Watch watch)
        {
            watch.TimeLeft -= Notify;
        }

        /// <summary>
        /// Call when anyone notify.
        /// </summary>
        /// <param name="sender">sender of notify</param>
        /// <param name="timeLeftEventArgs">arguments of the notify</param>
        protected abstract void Notify(object sender, TimeLeftEventArgs timeLeftEventArgs);
    }
}
