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

            HttpCookie cookie = Request.Cookies.Get("GuessingGame");
            if (cookie == null)
            {
                cookie = new HttpCookie("GuessingGame");
                cookie.Value = "10";
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);
            }

            ViewBag.hiscore = "High Score: " + cookie.Value;

            return View();
        }

        [HttpPost]
        public ActionResult GuessingGame(string guessNumber)
        {
            string secret = Session["Number"] as string;
            int n, hs;
            string cv = "-1";

            HttpCookie cookie = Request.Cookies.Get("GuessingGame");

            if (cookie != null)
            {
                cv = cookie.Value;
                ViewBag.hiscore = "High Score: " + cv;
            }
            int r = Numbers.GuessNumber(guessNumber, secret);
            switch (r)
            {
                case 0:
                    if (cookie != null)
                    {
                        n = Int32.Parse(Session["Count"] as string);
                        hs = Int32.Parse(cookie.Value);
                        if (n < hs)
                        {
                            ViewBag.message = "GRATTIS! Nytt rekord med " + Session["Count"] + " försök! Det var " + secret + "! Slumpar nu fram ett nytt tal...";
                            cookie.Value = "" + n;
                            Response.Cookies.Add(cookie);
                        }
                        else
                            ViewBag.message = "GRATTIS! Du gissade rätt på " + Session["Count"] + " försök! Det var " + secret + "! Slumpar nu fram ett nytt tal...";
                    }
                    else
                        ViewBag.message = "GRATTIS! Du gissade rätt på " + Session["Count"] + " försök! Det var " + secret + "! Slumpar nu fram ett nytt tal...";
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