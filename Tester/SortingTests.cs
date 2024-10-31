using SortWords.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortWords.Tests
{
    [TestFixture]
    public class SortingTests
    {
        [Test]
        public void Test_Sorting_AscendingOrder()
        {
            var words = new List<string> { "orange", "apple", "banana", "grape" };
            var sortedWords = words.SortBy(ascending: true);

            Assert.That(sortedWords, Is.EquivalentTo(new List<string> { "apple", "banana", "grape", "orange" }));
        }

        [Test]
        public void Test_Sorting_DescendingOrder()
        {
            var words = new List<string> { "orange", "apple", "banana", "grape" };
            var sortedWords = words.SortBy(ascending: false);
            Assert.That(sortedWords, Is.EquivalentTo(new List<string> { "orange", "grape", "banana", "apple" }));
        }
    }

}
