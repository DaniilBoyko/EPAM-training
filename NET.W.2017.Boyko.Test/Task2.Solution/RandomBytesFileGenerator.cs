using System;

namespace Task2.Solution
{
    /// <summary>
    /// Class for generate files with random bytes.
    /// </summary>
    public class RandomBytesFileGenerator : RandomSymbolGenerator
    {
        /// <summary>
        /// Consturctor initialize the instance of the <see cref="RandomBytesFileGenerator"/> class.
        /// </summary>
        /// <param name="workingDirectory">directory to save files</param>
        /// <param name="fileExtension">extensiont of the file</param>
        public RandomBytesFileGenerator(string workingDirectory, string fileExtension) : base(workingDirectory,
            fileExtension)
        {
        }

        /// <inheritdoc></inheritdoc>
        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}