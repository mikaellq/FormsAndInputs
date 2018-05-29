using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormsAndInputs.Models
{
    public class Person
    {
        public int Idx { get; set; }
        public string Name { get; set; }
        public string Phonenr { get; set; }
        public string City { get; set; }

        public Person(int idx, string name, string phonenr, string city)
        {
            Idx = idx;
            Name = name;
            Phonenr = phonenr;
            City = city;
        }
    }

    public static class PersonList
    {
        public static List<Person> GetPersonList()
        {
            Person person1 = new Person(0, "Karl", "070-123456", "Göteborg");
            Person person2 = new Person(1, "Lisa", "072-5673563", "Malmö");
            Person person3 = new Person(2, "Peter", "073-6747656", "Falköping");
            Person person4 = new Person(3, "Mikael", "078-1342532", "Ulricehamn");
            Person person5 = new Person(4, "Jonathan", "074-566758", "Skövde");

            List<Person> personList = new List<Person>();

            personList.Add(person1);
            personList.Add(person2);
            personList.Add(person3);
            personList.Add(person4);
            personList.Add(person5);

            return personList;
        }
    }
}
