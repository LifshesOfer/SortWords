namespace SortWords.Core
{
    public class WordProcessor
    {
        private readonly Dictionary<string, int> WordFrequency = [];
        private KeyValuePair<string, int> MostFrequentWord = new();

        public static string[] GetLowercaseWords(string line)
        {
            return RegularExpressions.WhitespaceRegex()
                .Split(line)
                .Where(s => s != string.Empty)
                .Select(s => s.ToLowerInvariant()).ToArray();
        }

        public void ProcessLine(string line)
        {
            var trimmedLine = line.Trim();

            if (string.IsNullOrEmpty(trimmedLine))
                return;

            var words = GetLowercaseWords(trimmedLine);

            if (words.Length == 0)
                return;

            foreach (var word in words)
            {
                var hasKey = WordFrequency.TryGetValue(word, out int value);
                value = hasKey ? ++value : 1;
                WordFrequency[word] = value;

                if (value > MostFrequentWord.Value)
                {
                    MostFrequentWord = new KeyValuePair<string, int>(word, value);
                }
            }
        }

        public List<string> GetUniqueWords()
        {
            return [.. WordFrequency.Keys];
        }

        public KeyValuePair<string,int> GetMostFrequentWord()
        {
            return MostFrequentWord;
        }
    }
}
