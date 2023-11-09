/*==============================================================================
 *
 * Business logic for searching the web
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class SearchManager
    {
        private SearchAccess _searchAccess = new SearchAccess();
        public async Task<SearchResults> Search(SearchTerms searchTerms)
        {
            var searchResults = await _searchAccess.Search(searchTerms);
            var resultsList = new List<string>();

            var regex = new Regex(@"<a\s+href\s*=\s*[""']([^""']+)", RegexOptions.IgnoreCase);
            var matches = regex.Matches(searchResults.Response);


            int position = 0;
            //The for loop avoids first 12 links as they are not results from the search
            for(int i=12; i < matches.Count; i++)
            {
                if (matches[i].Value.Contains(searchTerms.Url))
                {
                    resultsList.Add(position.ToString());
                }
                position++;
            }
            if (resultsList.Count > 0)
            {
                searchResults.Poisitons = String.Join(", ", resultsList);
            }
            else
            {
                searchResults.Poisitons = "0";
            }
            return searchResults;
        }
    }
}
