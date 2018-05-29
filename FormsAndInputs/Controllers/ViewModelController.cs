using FormsAndInputs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsAndInputs.Controllers
{
    [Route("[controller]")]
    public class ViewModelController : Controller
    {
        // GET: ViewModel
        public ActionResult Index()
        {
            List<Person> personList = PersonList.GetPersonList();

            return View(personList);
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            List<Person> personList = PersonList.GetPersonList();
            List<Person> newList = new List<Person>();

            if (!String.IsNullOrEmpty(filter))
            {
                foreach (var item in personList)
                {
                    if (item.Name.Contains(filter) || item.City.Contains(filter) || item.Phonenr.Contains(filter))
                    {
                        newList.Add(item);
                    }
                }
            }
            else
                newList = personList;

            return View(newList);
        }

        public ActionResult Delete(int id)
        {
            
            return View();
        }
    }
}
