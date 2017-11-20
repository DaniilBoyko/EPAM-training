using System;

namespace Matrix
{
    /// <summary>
    /// Argument for change cell event.
    /// </summary>
    public class ChangeCellEventArgs : EventArgs
    {
        #region public Constructors

        /// <summary>
        /// Constructor initialize the instance of the <see cref="ChangeCellEventArgs"/> class.
        /// </summary>
        /// <param name="row">row of cell</param>
        /// <param name="column">index of cell</param>
        public ChangeCellEventArgs(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        #endregion // !public Constructors

        #region public Properties

        /// <summary>
        /// Get row of change cell.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Get column of change cell.
        /// </summary>
        public int Column { get; }

        #endregion // !public Properties
    }
}
