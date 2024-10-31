using SortWords.Core.Extensions;

namespace SortWords.Core
{
    internal class ConsoleApp
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.CreateConfiguration(args);
            config.Run().GetAwaiter().GetResult();
        }
    }
}
