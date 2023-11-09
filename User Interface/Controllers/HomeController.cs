/*==============================================================================
 *
 * Controller for the search screen 
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;
using BusinessLogic;
using Models;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class HomeController : BaseController
    {
        private SearchManager _searchManager = new SearchManager();
        public ActionResult Index()
        {
            return View(new SearchViewModel()
            {
                Results = new List<SearchResults>()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                SearchResults searchResults = await _searchManager.Search(new SearchTerms
                {
                    Keywords = search.Keywords,
                    Url = search.Url
                });
                if(search.Results == null)
                {
                    search.Results = new List<SearchResults>();
                }
                search.Results.Add(searchResults);
            }
            if (search.Results == null)
            {
                search.Results = new List<SearchResults>();
            }
            return View(search);
        }
    }
}