using SortWords.Core.Models;

namespace SortWords.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static async Task Run(this Configuration configuration)
        {
            var wordProcessor = await FileProcessor.ProcessFile(configuration.InputFile);
            var uniqueWords = wordProcessor.GetUniqueWords();
            var sortedWords = uniqueWords.Sort(configuration.Ascending);

            await FileProcessor.WriteFile(configuration.OutputFile, sortedWords);
            var mostFrequest = wordProcessor.GetMostFrequentWord();
            Console.WriteLine($"F2 content:\n{sortedWords}");
            Console.WriteLine($"The most frequent word in the text is '{mostFrequest.Key}', count: {mostFrequest.Value}");
        }
    }
}
