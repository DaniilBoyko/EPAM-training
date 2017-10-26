using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NumberFunctions
{
    public static class Extensions
    {
        #region Puplic Methods

        /// <summary>
        /// Convert dobule number to binary string
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Binary string</returns>
        public static string GetBinaryString(this double number)
        {
            long longBytes = new DoubleLongUnion { Double = number }.Long;
            string resultString = "";

            for (int i = 0; i < DoubleBits; i++)
            {
                if (longBytes == longBytes >> 1 << 1)
                    resultString = "0" + resultString;
                else
                    resultString = "1" + resultString;
                longBytes >>= 1;
            }

            return resultString;
        }

        #endregion

        #region Constants

        private const int DoubleBits = 64;

        #endregion

        #region Private Structs

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLongUnion
        {
            [FieldOffset(0)] private long n_long;
            [FieldOffset(0)] private double n_double;

            public long Long
            {
                get => n_long;
                set => n_long = value;
            }

            public double Double
            {
                get => n_double;
                set => n_double = value;
            }
        }

        #endregion
    }
}
