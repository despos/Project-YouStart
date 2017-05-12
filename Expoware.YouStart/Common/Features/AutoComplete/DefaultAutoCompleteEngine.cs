using System.Collections.Generic;
using System.Linq;
using Expoware.YouStart.Common.Extensions;

namespace Expoware.YouStart.Common.Features.AutoComplete
{
    public class DefaultAutoCompleteEngine : IAutoCompleteEngine
    {
        protected readonly IList<ISearchEngine> Engines = new List<ISearchEngine>();

        public virtual IEnumerable<AutoCompleteItem> GetHints(string[] tokens, int maxRows = 15, SearchType typeOfSearch = SearchType.Or)
        {
            var hints = new List<AutoCompleteItem>();
            foreach (var e in Engines)
            {
                if (!e.CanHandle(tokens)) continue;

                var searchEngineHints = e.GetHints(tokens, maxRows, typeOfSearch);
                hints.AddRange(searchEngineHints);
            }
            return hints;
        }

        public IEnumerable<AutoCompleteItem> GetHints(string token, int maxRows = 15, SearchType typeOfSearch = SearchType.Or)
        {
            var tokens = BreakUpQueryString(token);
            return GetHints(tokens);
        }
        public IAutoCompleteEngine AddSearchEngine(ISearchEngine engine)
        {
            Engines.Add(engine);
            return this;
        }


        #region VIRTUAL

        protected virtual string[] BreakUpQueryString(string query)
        {
            var orSymbols = new[] { ",", ";" };

            // Get the list of searchable tokens in the search string
            query = query.ToLower();
            var shouldStopAtFirstMatch = query.ContainsAny(orSymbols);
            query = query.ReplaceAny(" ", /* To be replaced */ ",", ";", "+", "*", "[", "]", "@");

            // Get the list of searchable tokens in the search string
            var tokens = query.ToLower().Split(' ');
            if (tokens.Length > 0)
            {
                tokens = tokens.Where(t => !t.IsNullOrWhitespace()).ToArray();
                return tokens;
            }
            return new[] { query };
        }
        #endregion
    }
}