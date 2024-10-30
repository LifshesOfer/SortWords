namespace SortWords
{
    internal class ConsoleApp
    {
        static void Main(string[] args)
        {
            var filePath = args.Length > 0 ? args[0] : null;
            if (!FileProcessor.ValidateFilePath(filePath, FileMode.Open, FileAccess.Read))
            {
                filePath = GetFilePath();
            }

            var ascending = GetSortOption();

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
                    Console.WriteLine("Sorting option is not in a recognized format ('sort a', 'sort d')");
                    ascending = GetSortOption();
                    break;
            }
            return ascending;
        }

        private static string GetFilePath()
        {
            string? filePath;
            do
            {
                Console.WriteLine("Please enter input file path");
                filePath = Console.ReadLine();

            }while(!FileProcessor.ValidateFilePath(filePath, FileMode.Open, FileAccess.Read));

            return filePath!;

        }
    }
}
