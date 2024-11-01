using SortWords.Core;
using SortWords.Core.Extensions;
using SortWords.Core.Models;

namespace SortWords.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        private static readonly object[] TestData = [
            new object[] { "C:\\Users\\Ofer\\source\\repos\\SortWords\\Tester\\TestData\\InMyLife.txt", "all, and, are, better, can, changed, dead, for, forever, friends, gone, have, i, in, life, living, loved, lovers, moments, my, not, places, recall, remain, remember, some, still, their, them, there, these, though, will, with", new MostFrequent(["some"], 6)},
            new object[] { "C:\\Users\\Ofer\\source\\repos\\SortWords\\Tester\\TestData\\TiedWords.txt", "an, ana, ban, banana, test", new MostFrequent(["banana", "test"], 3)},
            new object[] { "C:\\Users\\Ofer\\source\\repos\\SortWords\\Tester\\TestData\\DoesNotExist.txt", "", new MostFrequent()},
            ];

        [TestCaseSource(nameof(TestData))]
        public async Task Test1(string filePath, string expectedString, MostFrequent expectedFrequent)
        {
            var wordProcessor = await FileProcessor.ProcessFile(filePath);

            var uniqueWords = wordProcessor.GetUniqueWords();
            uniqueWords.Sort();
            var sortedWords = string.Join(", ", [.. uniqueWords]);
            var mostFrequent = wordProcessor.GetMostFrequent();
            Assert.Multiple(() =>
            {
                Assert.That(mostFrequent, Is.EqualTo(expectedFrequent));
                Assert.That(sortedWords, Is.EqualTo(expectedString));
            });
        }

        [Test]
        public async Task Test_Configuration_AscendingSort()
        {
            var outputPath = "output.txt";
            
            var config = ConfigurationFactory.CreateConfiguration(["C:\\Users\\Ofer\\source\\repos\\SortWords\\Tester\\TestData\\InMyLife.txt", "sort a", outputPath]);
            await config.Run();

            var actual = File.ReadAllText(outputPath);
            var expected = File.ReadAllText("C:\\Users\\Ofer\\source\\repos\\SortWords\\Tester\\TestData\\InMyLifeExpected.txt");
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}