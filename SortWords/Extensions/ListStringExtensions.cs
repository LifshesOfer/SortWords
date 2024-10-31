namespace SortWords.Core.Extensions
{
    public static class ListStringExtensions
    {
        public static List<string> SortBy(this List<string> list, bool ascending)
        {
            if (list == null) 
                return [];

            var sortedList = new List<string>(list);
            if (ascending)
            {
                sortedList.Sort((a,b) => a.CompareTo(b));
            }
            else
            {
                sortedList.Sort((a, b) => b.CompareTo(a));
            }

            return sortedList;
        }
    }
}
