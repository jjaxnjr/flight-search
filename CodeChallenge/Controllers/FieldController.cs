using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class FieldController : Controller
    {
        // GET: Field
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFlights(string from, string to)
        {
            return Json(new Flight(), JsonRequestBehavior.AllowGet);
        }
    }
}