using System.Collections.Generic;

namespace Expoware.YouStart.Common.Features.AutoComplete
{
    public class AutoCompleteHelpers
    {
        public static bool IsMatch(string targetText, ICollection<string> tokens, SearchType typeOfSearch = SearchType.Or)
        {
            var normalized = targetText.ToLower();
            var count = tokens.Count;
            var counter = 0;
            foreach (var t in tokens)
            {
                var normalizedToken = t.ToLower().Trim();
                if (normalized.Contains(normalizedToken))
                {
                    if (typeOfSearch == SearchType.Or) return true;
                    counter++;
                }
            }
            return count == counter;
        }
    }
}