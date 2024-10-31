namespace SortWords.Core.Models
{
    public class Configuration(string inputFile, string outputFile, bool ascending)
    {
        public string InputFile { get; } = inputFile;
        public string OutputFile { get; } = outputFile;
        public bool Ascending { get; } = ascending;
    }
}
