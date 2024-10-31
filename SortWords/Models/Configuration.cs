namespace SortWords.Core.Models
{
    public class Configuration(string InputFile, string OutputFile, bool Ascending)
    {
        public string InputFile { get; } = InputFile;
        public string OutputFile { get; } = OutputFile;
        public bool Ascending { get; } = Ascending;
    }
}
