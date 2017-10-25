using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFunctions
{
    public static class Extensions
    {
        private static bool CheckDouble(double number, out string binaryString)
        {
            binaryString = "";

            if (double.IsNegativeInfinity(1 / number))
                binaryString = new string('0', 64);
            if (double.IsPositiveInfinity(1 / number))
                binaryString = "1" + new string('0', 63);
            if (double.IsPositiveInfinity(number))
                binaryString = "0" + new string('1', 11) + new string('0', 52);
            if (double.IsNegativeInfinity(number))
                binaryString = new string('1', 12) + new string('0', 52);
            if (double.IsNaN(number))
                binaryString = new string('1', 13) + new string('0', 51);

            if (binaryString == "")
                return false;
            else
                return true;
        }

        /// <summary>
        /// Convert dobule number to binary string
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Binary string</returns>
        public static string GetBinaryString(this double number)
        {
            if (CheckDouble(number, out string binaryString))
                return binaryString;

            return "";
        }
    }
}
