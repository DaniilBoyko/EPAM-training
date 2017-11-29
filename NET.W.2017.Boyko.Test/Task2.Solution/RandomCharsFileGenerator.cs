using System;
using System.Linq;
using System.Text;

namespace Task2.Solution
{
    /// <summary>
    /// Class for generate files with random chars.
    /// </summary>
    public class RandomCharsFileGenerator : RandomSymbolGenerator
    {
        /// <summary>
        /// Constructor initialize the instance of the <see cref="RandomCharsFileGenerator"/> class
        /// </summary>
        /// <param name="workingDirectory">directory to save files</param>
        /// <param name="fileExtension">extension of the file</param>
        public RandomCharsFileGenerator(string workingDirectory, string fileExtension) : base(workingDirectory, fileExtension)
        {
        }

        /// <inheritdoc></inheritdoc>
        protected override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = this.RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        /// <summary>
        /// Generate random string.
        /// </summary>
        /// <param name="size">size of the string</param>
        /// <returns>Generated string.</returns>
        private string RandomString(int size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }
}