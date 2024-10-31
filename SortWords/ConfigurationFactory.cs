using SortWords.Core.Models;

namespace SortWords.Core
{
    public class ConfigurationFactory
    {
        public static Configuration CreateConfiguration(string[] args)
        {
            var inputFile = args.Length > 0 ? args[0] : "";
            if (!FileProcessor.ValidateFilePath(inputFile, FileMode.Open, FileAccess.Read))
            {
                inputFile = GetInputFilePath();
            }

            if(args.Length < 2 || !TryConvertSortOption(args[1], out bool ascending))
            {
                ascending = GetSortOption();
            }

            var outputFile = args.Length > 2 ? args[2] : "";
            if (!FileProcessor.ValidateFilePath(outputFile, FileMode.Create, FileAccess.Write))
            {
                outputFile = GetOutputFilePath();
            }
            

            return new(inputFile, outputFile, ascending);
        }


        private static bool GetSortOption()
        {
            Console.WriteLine("Enter your options:");
            var inputLine = Console.ReadLine();
            bool ascending;
            if(!TryConvertSortOption(inputLine, out ascending))
            {
                Console.WriteLine("Sorting option not supported. Supported options are: 'sort a' and 'sort d'");
                ascending = GetSortOption();
            }
            
            return ascending;
        }

        private static bool TryConvertSortOption(string? sortOption, out bool ascending)
        {
            switch (sortOption?.ToLowerInvariant())
            {
                case "sort a":
                    ascending = true;
                    break;
                case "sort d":
                    ascending = false;
                    break;
                default:
                    ascending = false;
                    return false;
            }
            return true;
        }

        private static bool ValidateSortOption(string sortOption)
        {
            var validOptions = new string[] { "sort a", "sort d" };
            if(!validOptions.Contains(sortOption))
            {
                Console.WriteLine($"Sorting option not supported. Supported options are: '{string.Join("', '")}'");
                return false;
            }
            else
            {
                return true;
            }
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
