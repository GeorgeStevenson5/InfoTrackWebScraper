/*==============================================================================
 *
 * Data access for searching the web
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace DataAccess
{
    public class SearchAccess
    {
        public async Task<SearchResults> Search(SearchTerms searchTerms)
        {
            string response;
            var baseAddress = new Uri("https://www.google.co.uk/");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler) { BaseAddress = baseAddress})
            {

                string search = $"search?q=" + string.Join("+", searchTerms.Keywords.Split(' ')) +"&num=100";

                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agen", 
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                    "(KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36 Edg/119.0.0.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");

                //Adding cookie to show that consent has been given to use cookies.
                //This avoids the google cookie consent page appearing
                cookieContainer.Add(baseAddress, new Cookie("SOCS", "CAESHAgCEhJnd3NfMjAyMzExMDItMF9SQzIaAmVuIAEaBgiAn6uqBg"));

                var request = new HttpRequestMessage(HttpMethod.Get, search);
                HttpResponseMessage httpResponse = await client.SendAsync(request);

               
                response = await httpResponse.Content.ReadAsStringAsync();
            }
            return new SearchResults
            {
                Url = searchTerms.Url,
                Keywords = searchTerms.Keywords,
                Response = response
            };
        }

    }
}
