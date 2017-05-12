using System;
using System.Collections.Generic;

namespace Expoware.YouStart.Common.Features.AutoComplete
{
    public interface IAutoCompleteEngine
    {
        IAutoCompleteEngine AddSearchEngine(ISearchEngine engine);

        IEnumerable<AutoCompleteItem> GetHints(String[] tokens, Int32 maxRows = 15, SearchType typeOfSearch = SearchType.Or);

        IEnumerable<AutoCompleteItem> GetHints(String token, Int32 maxRows = 15, SearchType typeOfSearch = SearchType.Or);
    }
}