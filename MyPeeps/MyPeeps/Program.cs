using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeeps
{
    class Program
    {
        //need to:
        //print list of people 
        //add people to list
        //add team members to list
        //quit
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<TeamMember> teamMemberList = new List<TeamMember>();

            personList.Add(new Person("Bob", "Valentic", 26, "rvalentic@outlook.com"));
            teamMemberList.Add(new TeamMember("Hemory", "Pfifer", 15, "hpfifer@quickenloans.com", 50000));

            Console.WriteLine("Welcome to the list of people and team members!");

            bool keepGoing = true;
            while (keepGoing)
            {
                PrintOptions();
                int inputChoice = Validator.CheckNum("","Please enter a number 1 to 5: ", 5, 1);
                if (inputChoice == 1)
                {
                    PrintPersonList(personList);
                }
                else if (inputChoice == 2)
                {
                    PrintTeamMemberList(teamMemberList);
                }
                else if (inputChoice == 3)
                {
                    Person newPerson = Person.CreatePerson();
                    Console.WriteLine("\nThank you! We have received the following input:");
                    Person.PrintPerson(newPerson);
                    personList.Add(newPerson);
                }
                else if (inputChoice == 4)
                {
                    TeamMember newTeamMember = TeamMember.CreateTeamMember();
                    Console.WriteLine("\nThank you! We have received the following input:");
                    TeamMember.PrintTeamMember(newTeamMember);
                    personList.Add(newTeamMember);
                }
                else keepGoing = Quitter();
            }
        }

        static void PrintOptions()
        {
            Console.WriteLine(@"
What would you like to do?
1 -- show list of people
2 -- show list of team members
3 -- add person to list
4 -- add team member to list
5 -- quit");
        }

        static void PrintPersonList(List<Person> personList)
        {
            if (personList.Count == 0)
            {
                Console.WriteLine("I'm sorry, there is no one in the list.");
            }
            else
            {
                foreach (var person in personList)
                {                    
                    Person.PrintPerson(person);
                    Console.WriteLine();
                }
            }            
        }

        static void PrintTeamMemberList(List<TeamMember> teamMemberList)
        {
            if (teamMemberList.Count == 0)
            {
                Console.WriteLine("I'm sorry, there is no one in the list.");
            }
            else
            {
                foreach (var teamMember in teamMemberList)
                {
                    TeamMember.PrintTeamMember(teamMember);
                    Console.WriteLine();
                }
            }
        }

        public static bool Quitter()
        {
            bool correctInput;
            Console.WriteLine("Are you sure you want to quit?");
            do
            {
                string quitInput = Console.ReadLine().ToLower();
                if (quitInput == "y" || quitInput == "yes")
                {
                    Console.WriteLine("Come back soon!");
                    Console.ReadKey();
                    return false;

                }
                else if (quitInput == "n" || quitInput == "no")
                {
                    Console.WriteLine("\nOkay!\n");
                    correctInput = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("I'm sorry, I don't understand. Please respond y/n or yes/no: ");
                    correctInput = false;
                }

            } while (!correctInput);
            return true;
        }
    }
}
