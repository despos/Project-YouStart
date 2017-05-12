using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expoware.YouStart.Common.Features.AutoComplete
{
    public class CollectionSearchEngine<T> : ISearchEngine
    {
        private readonly IList<T> _data = new List<T>();
        private readonly Func<T, AutoCompleteItem> _builder = null;
        //private readonly string[] _properties = null;
        private readonly Func<T, string>[] _properties = null;

        public CollectionSearchEngine(IList<T> data, Func<T, AutoCompleteItem> builder, params Func<T, string>[] properties)
        {
            _data = data;
            _builder = builder;
            _properties = properties;
        }

        public bool CanHandle(string[] tokens)
        {
            return true;
        }

        public IEnumerable<AutoCompleteItem> GetHints(string[] tokens, int maxRows = 15, SearchType typeOfSearch = SearchType.Or)
        {
            if (_builder == null)
                return new List<AutoCompleteItem>();
            var hints = _data.Where(t => CanMatch(t, tokens, typeOfSearch))
                .Select(_builder)
                .Take(maxRows)
                .ToList();

            //t => new AutoCompleteItem
            //    {
            //        value = t.Title,
            //        id = "t-" + t.Id.ToString(CultureInfo.InvariantCulture),
            //        label = Format(t.Title, tokens)
            //    }))
            //    .Take(maxRows)
            //    .ToList();
            return hints;
        }


        protected virtual bool CanMatch(T item, IList<String> tokens, SearchType typeOfSearch = SearchType.Or)
        {
            var b = new StringBuilder();
            foreach (var p in _properties)
            {
                b.AppendFormat("{0} | ", p(item));
            }

            var text = b.ToString().Trim(' ', '|');

            var normalized = text.ToLower();
            var count = tokens.Count;
            var counter = 0;
            foreach (var t in tokens)
            {
                var normalizedToken = t.ToLower().Trim();
                if (normalized.Contains(normalizedToken))
                {
                    if (typeOfSearch == SearchType.Or)
                        return true;
                    counter++;
                }
            }
            return count == counter;
        }
    }
}