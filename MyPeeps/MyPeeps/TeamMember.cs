using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeeps
{
    class TeamMember : Person
    {
        public int Salary { get; set; }
        public string Address { get; set;} 

        public TeamMember(string firstName, string lastName, int age, string email, int salary, string address)
            : base(firstName, lastName, age, email)
        {
            Salary = salary;
            Address = address;
            if (age < 18)
            {
                Age = 18;//team members need to at least be adults
                isAnAdult = true;
            }
        }
        //build specs show the method to create team members doesn't have an address parameter
        //so we need a constructor without one
        public TeamMember(string firstName, string lastName, int age, string email, int salary) 
            : base(firstName, lastName, age, email)
        {
            Salary = salary;
            Address = "Earth";
            if (age < 18)
            {
                Age = 18;
                isAnAdult = true;
            }
        }

        public static TeamMember CreateTeamMember()
        {//first,last,email,age,salary

            string firstName = Validator.CheckName("Enter team member's first name: ",
                "\nPlease enter a valid first name (all letters, first letter capitalized): ");
            string lastName = Validator.CheckName("Enter team member's last name: ",
                "\nPlease enter a valid last name (all letters, first letter capitalized): ");
            int age = Validator.CheckNum("Enter team member's age: ", "\nPlease enter a positive whole number " +
                "(that is reasonable for a person's age): ", 122, 1);
            if (age < 18)
            {
                Console.WriteLine("Team members must be adults. Changing age to 18.");
            }
            string email = Validator.CheckEmail("Enter team member's email address: ");
            int salary = Validator.CheckNum("Enter team member's salary: ", 
                "Please enter a valid number for team member's salary: ", 1000000000, 0);
            //one billion dollars seems like a reasonable maximum salary to allow

            return new TeamMember(firstName, lastName, age, email, salary);
        }

        public static void PrintTeamMember(TeamMember teamMember)
        {
            Console.WriteLine($@"Team Member:
------------
First name: {teamMember.FirstName} 
Last name: {teamMember.LastName}
Age: {teamMember.Age}
Email: {teamMember.Email}");
            if (teamMember.isAnAdult) Console.WriteLine("Is an adult: Yes");
            else Console.WriteLine("Is an adult: No");
            Console.WriteLine($@"Salary: ${teamMember.Salary}
Address: {teamMember.Address}");
        }
    }
}
