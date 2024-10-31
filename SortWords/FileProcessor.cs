using System.Text.RegularExpressions;

namespace SortWords
{
    internal class FileProcessor
    {
        /// <summary>
        /// Validates a file path by checking if it is non-empty and accessible with the specified mode and access.
        /// </summary>
        /// <param name="filePath">The path of the file to validate. Can be <c>null</c> or empty.</param>
        /// <param name="fileMode">The <see cref="FileMode"/> to specify how the file should be opened (e.g., Open, Create).</param>
        /// <param name="fileAccess">The <see cref="FileAccess"/> to specify the level of access (e.g., Read, Write).</param>
        /// <returns>
        /// <c>true</c> if the file path is valid and the file can be opened with the given mode and access; otherwise, <c>false</c>.
        /// </returns>
        public static bool ValidateFilePath(string? filePath, FileMode fileMode, FileAccess fileAccess)
        {
            if(string.IsNullOrEmpty(filePath)) 
            {
                Console.WriteLine("File path empty");
                return false; 
            }
            try
            {
                using var fs = File.Open(filePath, fileMode, fileAccess);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open file '{0}' - {1}", filePath, ex.Message);
                return false;
            }
            return true;
        }

        public static async Task<WordProcessor> ProcessFile(string filePath)
        {
            var wordProcessor = new WordProcessor();
            var asyncLines = File.ReadLinesAsync(filePath);
            await foreach(var asyncLine in asyncLines)
            {
                if (string.IsNullOrEmpty(asyncLine))
                {
                    continue;
                }
                wordProcessor.ProcessLine(asyncLine);
            }

            return wordProcessor;

        }
    }
}
