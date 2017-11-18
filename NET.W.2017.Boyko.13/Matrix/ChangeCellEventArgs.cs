using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
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

        public int Row { get; }

        public int Column { get; }

        #endregion // !public Properties
    }
}
