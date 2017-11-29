using Task2.Solution;

namespace Task2.Tests
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
