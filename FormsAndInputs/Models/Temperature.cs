using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormsAndInputs.Models
{
    public static class Temperature
    {
        public static string FeberTest(string input, string unit)
        {
            string s = "";
            float number = 0;

            if (!float.TryParse(input, out number))
            {
                return "Vänligen skriv in din temperatur!";
            }

            if (unit == "Fahrenheit")
                number = (number - 32) / 1.8f;

            if (number >= 40)
                s = "Du har hög feber";
            else if (number >= 38)
                s = "Du har feber";
            else if (number >= 36)
                s = "Du är feberfri";
            else
                s = "Du är nedkyld";

            return s;
        }
    }
}
