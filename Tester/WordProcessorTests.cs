using SortWords.Core;
using SortWords.Core.Models;
using SortWords.Tests.TestData;

namespace SortWords.Tests
{
    [TestFixture]
    internal class WordProcessorTests
    {
        [Test]
        public void Test_WordProcessing_LowerCaseConversion()
        {
            var line = "Apple Banana APPLE banana";
            var processor = new WordProcessor();
            processor.ProcessLine(line);

            Assert.That(processor.GetUniqueWords(), Is.EquivalentTo(new List<string> { "apple", "banana" }));
        }

        [Test]
        public void Test_WordProcessing_DuplicateRemoval()
        {
            var line = "test Test TEST tEst";
            var processor = new WordProcessor();
            
            processor.ProcessLine(line);

            Assert.That(processor.GetUniqueWords(), Has.Count.EqualTo(1));
        }

        [Test]
        public void Test_WordProcessing_FrequencyCounting()
        {
            var line = "apple banana apple orange banana apple";
            var processor = new WordProcessor();
            processor.ProcessLine(line);

            var wordsFrequency = processor.GetWordsFrequency();
            var expected = new Dictionary<string, int>
            {
                { "apple", 3 },
                { "banana", 2 },
                { "orange", 1 }
            };

            Assert.That(wordsFrequency, Is.EquivalentTo(expected));
        }

        [Test]
        public void Test_MostFrequentWord_SingleMax()
        {
            var line = "apple banana apple orange banana apple";
            var processor = new WordProcessor();
            
            processor.ProcessLine(line);

            var mostFrequent = processor.GetMostFrequent();
            var expected = new MostFrequent(["apple"], 3);

            Assert.That(mostFrequent, Is.EqualTo(expected));
        }

        [Test]
        public void Test_MostFrequentWord_Tie()
        {
            var line = "apple banana apple banana";
            var processor = new WordProcessor();
            
            processor.ProcessLine(line);

            var mostFrequent = processor.GetMostFrequent();
            var expected = new MostFrequent(["apple", "banana"], 2);

            Assert.That(mostFrequent, Is.EqualTo(expected));
        }

        [Test]
        public void Test_MostFrequentWord_NoWords()
        {
            var processor = new WordProcessor();
            var line = "";
            processor.ProcessLine(line);

            var mostFrequent = processor.GetMostFrequent();
            var expectFrequency = new MostFrequent();
            Assert.Multiple(() =>
            {
                Assert.That(mostFrequent, Is.EqualTo(expectFrequency));
                Assert.That(processor.GetWordsFrequency(), Is.EqualTo(new Dictionary<string, int>()));
            });
        }
    }
}
