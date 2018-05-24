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
            return Redirect("/CheckTemp/");
        }
        
        public ActionResult CheckTemp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckTemp(string input, string unit)
        {
            ViewBag.Result = Temperature.FeberTest(input, unit);

            return View();
        }
    }
}