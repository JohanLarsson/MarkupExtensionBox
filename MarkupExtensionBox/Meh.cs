using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkupExtensionBox
{
    public class Meh
    {
        public static string Value = "MEH";

        public static IReadOnlyList<StringComparison> Comparisons =
            Enum.GetValues(typeof(StringComparison)).Cast<StringComparison>().ToArray();

        private static IEnumerable<T> Repeat<T>(T item)
        {
            while (true)
            {
                yield return item;
            }
        } 
    }
}
