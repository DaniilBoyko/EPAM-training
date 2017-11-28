using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomBytesFileGenerator randomBytesFile = new RandomBytesFileGenerator("Files with random bytes", ".txt");
            randomBytesFile.GenerateFiles(2, 100);
            RandomCharsFileGenerator randomCarsFile = new RandomCharsFileGenerator("Files with random chars", ".txt");
            randomCarsFile.GenerateFiles(2, 100);
        }
    }
}
