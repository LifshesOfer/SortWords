using SortWords.Models;

namespace SortWords
{
    internal class ConfigurationFactory
    {
        public static Configuration CreateConfiguration(string[] args)
        {
            var inputFile = args.Length > 0 ? args[0] : "";
            if (!FileProcessor.ValidateFilePath(inputFile, FileMode.Open, FileAccess.Read))
            {
                inputFile = GetInputFilePath();
            }

            var ascending = GetSortOption();

            var outputFile = GetOutputFilePath();

            return new(inputFile, outputFile, ascending);
        }

        private static bool GetSortOption()
        {
            Console.WriteLine("Enter your options:");
            var inputLine = Console.ReadLine();
            bool ascending;
            switch (inputLine?.ToLowerInvariant())
            {
                case "sort a":
                    ascending = true;
                    break;
                case "sort d":
                    ascending = false;
                    break;
                default:
                    Console.WriteLine("Sorting option not supported. Supported options are: 'sort a' and 'sort d'");
                    ascending = GetSortOption();
                    break;
            }
            return ascending;
        }

        private static string GetInputFilePath()
        {
            string? filePath;
            do
            {
                Console.WriteLine("Please enter input file path");
                filePath = Console.ReadLine();

            } while (!FileProcessor.ValidateFilePath(filePath, FileMode.Open, FileAccess.Read));

            return filePath!;
        }

        private static string GetOutputFilePath()
        {
            string? filePath;
            do
            {
                Console.WriteLine("Please enter output file path");
                filePath = Console.ReadLine();

            } while (!FileProcessor.ValidateFilePath(filePath, FileMode.Create, FileAccess.ReadWrite));

            return filePath!;
        }
    }
}
