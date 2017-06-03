using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ViewResult Index()
        {
            return View("Index");
        }
    }   
}
