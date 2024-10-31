using SortWords.Core;

namespace SortWords.Tests
{
    [TestFixture]
    public class FileProcessorTests
    {
        [Test]
        public async Task Test_OutputFile_SingleLineFormat()
        {
            var content = "apple, banana, grape, orange";
            string outputPath = "test_output.txt";
            await FileProcessor.WriteFile(outputPath, content);

            string outputContent = File.ReadAllText(outputPath).Trim();
            Assert.That(outputContent, Is.EqualTo("apple, banana, grape, orange"));
        }
    }

}
