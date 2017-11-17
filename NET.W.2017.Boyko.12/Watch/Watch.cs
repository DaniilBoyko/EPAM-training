using System;
using System.Threading;

namespace Watch
{
    /// <summary>
    /// Notify listeners when time is left.
    /// </summary>
    public class Watch
    {
        #region private Fields

        /// <summary>
        /// Store milliseconds of the watch.
        /// </summary>
        private long milSeconds;

        /// <summary>
        /// Store thread waiting of the watch.
        /// </summary>
        private Thread thread;

        #endregion // !private Fields

        #region public Constructors

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Watch"/> class.
        /// </summary>
        /// <param name="milSeconds"></param>
        public Watch(long milSeconds)
        {
            MilSeconds = milSeconds;
        }

        #endregion // !public Constructors

        #region public Delegates and Events

        /// <summary>
        /// Event for notify listeners of watch.
        /// </summary>
        public event EventHandler<TimeLeftEventArgs> TimeLeft = delegate { };

        #endregion // !poubic Delegates and Events

        #region private Properties

        /// <summary>
        /// Get or set seconds.
        /// </summary>
        private long MilSeconds
        {
            get => milSeconds;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException(nameof(milSeconds));
                }

                milSeconds = value;
            }
        }

        #endregion // !private Properties

        #region public Methods

        /// <summary>
        /// Set waiting seconds of watch.
        /// </summary>
        /// <param name="milseconds"></param>
        public void SetSeconds(int milseconds)
        {
            thread?.Abort();
            MilSeconds = milSeconds;
        }

        /// <summary>
        /// Start watch.
        /// </summary>
        public void Start()
        {
            thread = new Thread(() => Run(this));
            thread.Start();
        }

        #endregion // !public Methods

        #region protected Methods

        /// <summary>
        /// Call when time left.
        /// </summary>
        /// <param name="e">arguments</param>
        protected virtual void OnTimeLeft(TimeLeftEventArgs e)
        {
            TimeLeft(this, e);
        }

        #endregion // !protected Methods

        #region private Methods

        /// <summary>
        /// Run thread in watch.
        /// </summary>
        /// <param name="watch">instance of watch</param>
        private static void Run(Watch watch)
        {
            Thread.Sleep((int)watch.MilSeconds);
            watch.OnTimeLeft(new TimeLeftEventArgs("Time is LEFT!!!"));
        }

        #endregion // !private Methods
    }
}
