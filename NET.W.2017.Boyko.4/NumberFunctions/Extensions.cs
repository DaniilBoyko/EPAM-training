using System.Runtime.InteropServices;

namespace NumberFunctions
{
    /// <summary>
    /// This class extends double.
    /// </summary>
    public static class Extensions
    {
        #region private Constants

        private const int DoubleBits = 64;

        #endregion // !private Constants

        #region puplic Methods

        /// <summary>
        /// Convert double number to binary string
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Binary string</returns>
        public static string GetBinaryString(this double number)
        {
            long longBytes = new DoubleLongUnion { Double = number }.Long;
            string resultString = string.Empty;

            for (int i = 0; i < DoubleBits; i++)
            {
                if (longBytes == longBytes >> 1 << 1)
                {
                    resultString = "0" + resultString;
                }
                else
                {
                    resultString = "1" + resultString;
                }

                longBytes >>= 1;
            }

            return resultString;
        }

        #endregion // !public Methods

        #region private Structs

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLongUnion
        {
            [FieldOffset(0)] private readonly long numberLong;
            [FieldOffset(0)] private double numberDouble;

            public long Long => numberLong;

            public double Double
            {
                get => numberDouble;
                set => numberDouble = value;
            }
        }

        #endregion // !private Structs
    }
}
