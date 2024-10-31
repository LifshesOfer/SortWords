using SortWords.Core.Models;

namespace SortWords.Core
{
    public class WordProcessor : IEquatable<WordProcessor>
    {
        private readonly Dictionary<string, int> WordFrequency = [];
        private readonly HashSet<string> UniqueWords = [];
        private KeyValuePair<string, int> MostFrequentWord = new();

        private static string[] GetLowercaseWords(string line)
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

            ProcessWords(words);
        }

        private void ProcessWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                ProcessWord(word);
            }
        }

        private void ProcessWord(string word)
        {
            var newWord = UniqueWords.Add(word);
            if (newWord)
            {
                WordFrequency[word] = 1;
            }
            var value = newWord ? 1 : ++WordFrequency[word];

            if (value > MostFrequentWord.Value)
            {
                MostFrequentWord = new KeyValuePair<string, int>(word, value);
            }
        }

        public IDictionary<string, int> GetWordsFrequency()
        {
            return WordFrequency;
        }

        public List<string> GetUniqueWords()
        {
            return [.. UniqueWords];
        }

        public MostFrequent GetMostFrequent()
        {
            MostFrequent mostFrequent = new();
            var maxFrequency = MostFrequentWord.Value;
            
            if (maxFrequency == 0)
            {
                return mostFrequent;
            }
            mostFrequent.Words = WordFrequency.Where(wf => wf.Value == maxFrequency).Select(wf => wf.Key).ToArray();
            mostFrequent.Frequency = maxFrequency;
            return mostFrequent;
            
        }

        public bool Equals(WordProcessor? other)
        {
            return other != null &&
                Enumerable.SequenceEqual(this.WordFrequency, other.WordFrequency) 
                && other.MostFrequentWord.Key == this.MostFrequentWord.Key
                && other.MostFrequentWord.Value == this.MostFrequentWord.Value;
        }

        public override bool Equals(object? obj) => Equals(obj as WordProcessor);

        public override int GetHashCode()
        {
            return WordFrequency.GetHashCode() ^ UniqueWords.GetHashCode() ^ MostFrequentWord.GetHashCode();
        }
    }
}
