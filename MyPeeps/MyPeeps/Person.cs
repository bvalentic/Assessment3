using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeeps
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email {get; set;}
        public bool isAnAdult;

        public Person(string firstName, string lastName, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;

            if (age >= 18)
            {
                isAnAdult = true;
            }
            else isAnAdult = false;
        }

        public static Person CreatePerson()
        {
            string firstName = Validator.CheckName("Enter person's first name: ", 
                "\nPlease enter a valid first name (all letters, first letter capitalized): ");
            string lastName = Validator.CheckName("Enter person's last name: ",
                "\nPlease enter a valid last name (all letters, first letter capitalized): ");
            int age = Validator.CheckNum("Enter person's age: ", "\nPlease enter a positive whole number " +
                "(one that is reasonable for an adult person's age). \n" +
                "Please keep in mind the person must be an adult to be added to the list. " +
                "", 122, 18);
            //122 is the age of the oldest person ever
            string email = Validator.CheckEmail("Enter person's email address: ");
            return new Person(firstName, lastName, age, email);
        }

        public static void PrintPerson(Person person)
        {
            Console.WriteLine($@"Person:
-------
First name: {person.FirstName} 
Last name: {person.LastName}
Age: {person.Age}
Email: {person.Email}");
            if (person.isAnAdult) Console.WriteLine("Is an adult: Yes");
            else Console.WriteLine("Is an adult: No");            
        }        
    }
}
