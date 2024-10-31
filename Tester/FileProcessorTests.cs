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

        [Test]
        public async Task Test_ProcessFile_NoFile()
        {
            string filePath = "test_input.txt";
            var wordProcessor = await FileProcessor.ProcessFile(filePath);
            
            Assert.That(wordProcessor, Is.EqualTo(new WordProcessor()));
        }

        [Test]
        public async Task Test_OutputPath_NotValid()
        {
            var content = "apple, banana, grape, orange";
            string outputPath = @"DD:\hello.txt";
            string resultPath = await FileProcessor.WriteFile(outputPath, content);

            Assert.That(resultPath, Is.EqualTo(string.Empty));
        }
    }

}
