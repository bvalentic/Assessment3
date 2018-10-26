using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPeeps
{
    public class Validator
    {
        public static int CheckNum(string promptString, string errorMessage, int maxNum, int minNum)
        {//checks input string is of required type (in this case, non-zero positive doubles)
            Console.Write(promptString);
            string inputString = Console.ReadLine();
            int input;
            while ((!(int.TryParse(inputString, out input))) || int.Parse(inputString) < minNum || int.Parse(inputString) > maxNum)
            {//only positive non-zero numbers allowed
                Console.Write($"I'm sorry, that's not a valid input. {errorMessage}");
                inputString = Console.ReadLine();
            }
            return input;
        }
        public static string CheckName(string promptString, string errorMessage)
        {//checks a name was entered (a string of word characters beginning with an uppercase letter [and no digits])
            Console.Write(promptString);
            string inputString = Console.ReadLine();
            while (!(Regex.IsMatch(inputString, @"^[A-Z][a-z]+$")))
            {
                Console.Write($"I'm sorry, that's not a valid input. {errorMessage}");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
        public static string CheckEmail(string promptString)
        {
            Console.Write(promptString);
            string inputString = Console.ReadLine();
            while (!(Regex.IsMatch(inputString, @"\w+[@]\w+[.]\w+")))
            {
                Console.Write("I'm sorry, that's not a valid input. \n" +
                    "Please enter the email in a valid format: \"[local-part]@[domain].[com/org/etc]\"");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
    }
}
