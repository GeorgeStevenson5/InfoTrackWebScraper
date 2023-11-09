/*==============================================================================
 *
 * Model for the results of the web search
 * 
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SearchResults : SearchTerms
    {
        public string Poisitons{ get; set; }

        public string Response { get; set; }
    }
}
