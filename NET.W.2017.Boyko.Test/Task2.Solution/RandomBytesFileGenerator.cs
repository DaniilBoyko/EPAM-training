using System;
using System.IO;
using Task2.Solution;

namespace Task_2
{
    public class RandomBytesFileGenerator : RandomSymbolGenerator
    {
        public RandomBytesFileGenerator(string workingDirectory, string fileExtension) : base(workingDirectory,
            fileExtension)
        {
        }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}