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

        public ActionResult GuessingGame()
        {
            Random random = new Random();
            string s = "" + random.Next(0, 1000);
            Session["Number"] = s;
            Session["Count"] = "0";

            return View();
        }

        [HttpPost]
        public ActionResult GuessingGame(string guessNumber)
        {
            string secret = Session["Number"] as string;
            int n;

            int r = Numbers.GuessNumber(guessNumber, secret);
            switch(r)
            {
                case 0:
                    ViewBag.message = "GRATTIS! Du gissade rätt på "+ Session["Count"]+" försök! Det var "+secret+"! \nSlumpar nu fram ett nytt tal...";
                    Random random = new Random();
                    string s = "" + random.Next(0, 1000);
                    Session["Number"] = s;
                    Session["Count"] = "0";
                    break;
                case 1:
                    n = Int32.Parse(Session["Count"] as string);
                    n += 1;
                    Session["Count"] = "" + n;
                    ViewBag.message = Session["Count"] + ". Din gissning är för HÖG!";
                    break;
                case 2:
                    n = Int32.Parse(Session["Count"] as string);
                    n += 1;
                    Session["Count"] = "" + n;
                    ViewBag.message = Session["Count"] + ". Din gissning är för LÅG!";
                    break;
                case 3:
                    ViewBag.message = "Vänligen gissa ett tal mellan 0 och 1000!";
                    break;
                case 4:
                    ViewBag.message = "Något gick fel. Vänligen starta en ny session!";
                    break;
                default:
                    break;
            }

            return View();
        }
    }
}