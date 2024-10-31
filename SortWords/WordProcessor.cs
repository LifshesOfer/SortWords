﻿using SortWords.Core.Models;

namespace SortWords.Core
{
    public class WordProcessor
    {
        private readonly Dictionary<string, int> WordFrequency = [];
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
            var hasKey = WordFrequency.TryGetValue(word, out int value);
            value = hasKey ? ++value : 1;
            WordFrequency[word] = value;

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
            return [.. WordFrequency.Keys];
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
    }
}
