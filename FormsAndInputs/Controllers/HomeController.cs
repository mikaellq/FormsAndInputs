using FormsAndInputs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsAndInputs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Redirect("/Home/CheckNumber");
        }
        
        public ActionResult CheckNumber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckNumber(string input, string unit)
        {
            ViewBag.Result = Temperature.FeberTest(input, unit);

            return View();
        }
    }
}