using System;
using System.IO;

namespace Task2.Solution
{
    /// <summary>
    /// Class for generate file with random symbols.
    /// </summary>
    public abstract class RandomSymbolGenerator
    {
        /// <summary>
        /// Store directory to save files.
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// Store extension of the files.
        /// </summary>
        public string FileExtension { get; set; }
        
        /// <summary>
        /// Constructor initialize the instance of the class.
        /// </summary>
        /// <param name="workingDirectory">direcotry to save files</param>
        /// <param name="fileExtension">extension of the file</param>
        protected RandomSymbolGenerator(string workingDirectory, string fileExtension)
        {
            WorkingDirectory = workingDirectory;
            FileExtension = fileExtension;
        }

        /// <summary>
        /// Generate files
        /// </summary>
        /// <param name="filesCount">count of the files</param>
        /// <param name="contentLength">content lenght of the files</param>
        public virtual void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        /// <summary>
        /// Generate content of the files.
        /// </summary>
        /// <param name="contentLength">length of te content</param>
        /// <returns>arra of bytes</returns>
        protected abstract byte[] GenerateFileContent(int contentLength);

        /// <summary>
        /// Write bytes to file.
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <param name="content">content of the file</param>
        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
