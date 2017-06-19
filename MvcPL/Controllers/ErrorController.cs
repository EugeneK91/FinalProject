using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
           // Response.StatusCode = 404;
            return View("Error");
        }
    }
}