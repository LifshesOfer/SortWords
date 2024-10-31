using SortWords.Core;

namespace SortWords.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        private static readonly object[] TestData = [
            new object[] { "C:\\Users\\Ofer\\source\\repos\\SortWords\\Tester\\TestData\\InMyLife.txt", "all, and, are, better, can, changed, dead, for, forever, friends, gone, have, i, in, life, living, loved, lovers, moments, my, not, places, recall, remain, remember, some, still, their, them, there, these, though, will, with", new KeyValuePair<string,int>("some", 6) }
            ];

        [TestCaseSource(nameof(TestData))]
        public async Task Test1(string filePath, string expectedString, KeyValuePair<string, int> ExpectedWordCount)
        {
            var wordProcessor = await FileProcessor.ProcessFile(filePath);

            var uniqueWords = wordProcessor.GetUniqueWords();
            uniqueWords.Sort();
            var sortedWords = string.Join(", ", [.. uniqueWords]);
            Assert.Multiple(() =>
            {
                Assert.That(wordProcessor.GetMostFrequentWord(), Is.EqualTo(ExpectedWordCount));
                Assert.That(sortedWords, Is.EqualTo(expectedString));
            });
        }
    }
}