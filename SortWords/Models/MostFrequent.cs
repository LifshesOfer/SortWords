namespace SortWords.Core.Models
{
    public class MostFrequent : IEquatable<MostFrequent>
    {
        public string[] Words { get; set; }
        public int Frequency { get; set; }
        public MostFrequent()
        {
            Words = [];
            Frequency = 0;
        }

        public MostFrequent(string[] words, int frequency)
        {
            Words = words;
            Frequency = frequency;
        }

        public bool Equals(MostFrequent? other)
        {
            return (other != null &&
                Enumerable.SequenceEqual(this.Words, other.Words) &&
                other.Frequency == this.Frequency);
        }
    }
}
