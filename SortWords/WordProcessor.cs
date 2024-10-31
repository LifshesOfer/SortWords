namespace SortWords
{
    internal class WordProcessor
    {
        private readonly Dictionary<string, int> WordFrequency = new();
        private KeyValuePair<string, int> MostFrequentWord = new();

        public static string[] GetLowercaseWords(string line)
        {
            return RegularExpressions.WhitespaceRegex()
                .Split(line)
                .Where(s => s != String.Empty)
                .Select(s => s.ToLowerInvariant()).ToArray();
        }

        public void ProcessLine(string line)
        {
            var trimmedLine = line.Trim();

            if(string.IsNullOrEmpty(trimmedLine)) 
                return;

            var words = GetLowercaseWords(trimmedLine);

            if(words.Length == 0) 
                return;

            //InitFrequentWord(words[0]);

            foreach(var word in words)
            {
                var hasKey = WordFrequency.TryGetValue(word, out int value);
                value = hasKey ? ++value : 1;
                WordFrequency[word] = value;

                if(value > MostFrequentWord.Value)
                {
                    MostFrequentWord = new KeyValuePair<string, int>(word, value);
                }
            }
        }

        private void InitFrequentWord(string word)
        {
            if (string.IsNullOrEmpty(MostFrequentWord.Key))
            {
                MostFrequentWord = new KeyValuePair<string, int>(word, 1);
            }
        }
    }
}
