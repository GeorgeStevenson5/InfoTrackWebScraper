/*==============================================================================
 *
 * Base controller that all other controllers inherit from
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Loads error page whenever uncaught exception occurs
        /// </summary>
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Home/Error.cshtml"
            };
        }
    }
}