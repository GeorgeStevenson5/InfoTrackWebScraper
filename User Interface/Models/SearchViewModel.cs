/*==============================================================================
 *
 * View model for searching the web and showing the results
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Search phrase required")]
        public string Keywords { get; set; }
        [RegularExpression(@"(https://www.|http://www.|https://|http://)?[a-zA-Z0-9]{2,}(.+[a-zA-Z0-9]{2,})+", ErrorMessage = "Url is not in a valid format")]
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }

        public List<SearchResults> Results { get; set; }
    }
}