namespace SortWords.Core.Extensions
{
    internal static class ListStringExtensions
    {
        public static string Sort(this List<string> list, bool ascending)
        {
            if (list == null) 
                return string.Empty;
            if (ascending)
            {
                list.Sort((a,b) => a.CompareTo(b));
            }
            else
            {
                list.Sort((a, b) => b.CompareTo(a));
            }

            return string.Join(", ", [.. list]);
        }
    }
}
