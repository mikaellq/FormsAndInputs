using FormsAndInputs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsAndInputs.Controllers
{
    public class ViewModelController : Controller
    {
        public static List<Person> personList;

        // GET: ViewModel
        public ActionResult Index()
        {
            personList = PersonList.GetPersonList();

            return View(personList);
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            //List<Person> personList = PersonList.GetPersonList();
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

        public ActionResult Delete(string id)
        {
            int n = Int32.Parse(id);
            int index = personList.FindIndex(s => s.Idx.Equals(n));
            personList.RemoveAt(index);

            return View(personList);
        }

        [HttpPost]
        public ActionResult Add(string fname, string fnumber, string fcity)
        {
            int i = personList[personList.Count - 1].Idx + 1;
            Person p = new Person(i, fname, fnumber, fcity);
            personList.Add(p);

            return View(personList);
        }
    }
}
