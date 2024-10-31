using SortWords.Core.Models;

namespace SortWords.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static async Task Run(this Configuration configuration)
        {
            var wordProcessor = await FileProcessor.ProcessFile(configuration.InputFile);
            var uniqueWords = wordProcessor.GetUniqueWords();

            if (uniqueWords.Count == 0)
            {
                Console.WriteLine($"The file {configuration.InputFile} is empty - no file was created");
                return;
            }

            var sortedWords = uniqueWords.SortBy(configuration.Ascending);

            var outputFile = await FileProcessor.WriteFile(configuration.OutputFile, string.Join(", ", [.. sortedWords]));
            Console.WriteLine($"The file {outputFile} has been created.");
            var mostFrequent = wordProcessor.GetMostFrequent();
            
            if(mostFrequent.Words.Length > 1)
            {
                Console.WriteLine($"The most frequent words in the text are:\n '{string.Join("', '", mostFrequent.Words)}'.\n count: {mostFrequent.Frequency}");
            }
            else
            {
                Console.WriteLine($"The most frequent word in the text is {mostFrequent.Words[0]}.\n count: {mostFrequent.Frequency}");
            }
        }
    }
}
