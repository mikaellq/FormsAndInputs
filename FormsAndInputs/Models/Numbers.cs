using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FormsAndInputs.Models
{
    public class Numbers
    {
        public static int GuessNumber(string guessNumber, string secretNumber)
        {
            int guess, secret;

            if (!int.TryParse(guessNumber, out guess))
            {
                return 3;
            }

            if (!int.TryParse(secretNumber, out secret))
            {
                return 4;
            }

            if (guess == secret)
            {
                return 0;
            }
            else if (guess > secret)
            {
                return 1;
            }
            else return 2;
        }
    }
}