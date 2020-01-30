using System;
using System.Collections.Generic;

namespace Lab9RefactoringLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lets create some lists!!
            List<string> people = new List<string>();
            people.Add("Teddy");
            people.Add("Michelle");
            people.Add("Eric");
            people.Add("Stacey");

            List<string> favoriteCity = new List<string>();
            favoriteCity.Add("London");
            favoriteCity.Add("New York City");
            favoriteCity.Add("Paris");
            favoriteCity.Add("Chicago");

            List<string> petPeeves = new List<string>();
            petPeeves.Add("Snow");
            petPeeves.Add("Spiders");
            petPeeves.Add("Driving");
            petPeeves.Add("Dishes");

            // Let us say Hi to the user 
            Console.WriteLine("Guten Morgen und willkommen to our small class ");
            //utilizing a while loop so the user can continue to find out about different people

            // If the user chooses to contine then we execute methods below
            bool userContinue = true;
            while (userContinue)
            {
                // Giving the names of the people to be selected
                // PrintNames Method,
                PrintNames(people);

                //prompting user to select a number or write out the name


                int userChoice = ValidateSelection(people, "Enter the number or write the name of the person you want find out more about:  ");
                //sending data to method to print the information the user selected to view

                PrintInfoSelected(people[userChoice], favoriteCity[userChoice], petPeeves[userChoice]);
                //prompting the user to select another person

                Console.WriteLine("Do you want to pick another person?: y or n please ");
                string userInput = Console.ReadLine().ToLower();
                while (userInput != "y" && userInput != "n")
                {
                    // Add .ToLower to make sure user input case doesn't stop the program from working
                    Console.WriteLine("Please enter y to continue or input n to exit ");
                    userInput = Console.ReadLine().ToLower();
                }
                // User inputs 'n' we can leave the while loop with the break; below
                if (userInput == "n")
                {
                    break;
                }
            }
            // outside of the loop we say au revior to the user
            Console.WriteLine("Au Revior! ");
        }

        // Method to get input from the user and 
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        // Method will print out the spiffy strings
        public static void PrintNames(List<string> output) // changed from array[] to list<string> output
        {
            // Declaring j giving it a place holder of 1
            int j = 1;
            //default placeholder for an int is 0
            for (int i = 0; i < output.Count; i++) // changed from .Length to .Count
            {
                Console.WriteLine($"{j}. {output[i]} ");
                j++;
            }
        }

        //Method validating user input
        public static int ValidateSelection(List<string> peopleNames, string message) // changed from string[]
        {
            int userChoiceNum = 0; // zero is the place holder of the int dataType
            // if the condition are true for correct. While will begin to execute
            bool correct = true;
            while (correct)
            {
                try
                {
                    // declaring userPersonSelected string setting it to the GetUserInput method and passing the (message) parameter;
                    string userPersonSelected = GetUserInput(message);

                    // if the person selcted equals the list index zero[0]
                    if (userPersonSelected == peopleNames[0])
                    {
                        userChoiceNum = 0;
                    }
                    // else if the person selcted the list index one[1]
                    else if (userPersonSelected == peopleNames[1])
                    {
                        userChoiceNum = 1;
                    }
                    //else if the person selcted the list index two[2]
                    else if (userPersonSelected == peopleNames[2])
                    {
                        userChoiceNum = 2;
                    }
                    //else if the person selcted equals the list index three[3]
                    else if (userPersonSelected == peopleNames[3])
                    {
                        userChoiceNum = 3;
                    }
                    else
                    {
                        userChoiceNum = int.Parse(userPersonSelected) - 1; // - 1 lines the index pos 0 to user selection of 1
                        Console.WriteLine("You selected: " + peopleNames[userChoiceNum]);
                    }
                    correct = false; // bool  set to false to breakout
                }
                // Catching outofrangeexceptions, a user inputs a number not within the given range
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Sorry that was not a correct numerical choice! ");
                    // if the input given is out of range the app will inform the user the entry was incorrect
                    correct = true;
                }
                // If the user doesn't follow the format, format here being the spelling of the name
                catch (FormatException)
                {
                    Console.WriteLine("Please choose the number given or retype the name exactly has its given to you!");
                    // if the input given is spelled incorrectly the app will inform the user the entry was incorrect

                    correct = true;
                }
            }
            return userChoiceNum;
        }

        public static void PrintInfoSelected(string InputName, string favoritecity, string petPeeves)
        {
            // If input is incorrect we set this to true
            bool invalid = true;
            while (invalid)
            {
                // Within the while loop, since invalid is set to false we can continue
                invalid = false;
                //setting the string userSelect to GetUserInput method
                string userSelect = GetUserInput("What would you like to know? Please Enter \"favorite city\", \"pet peeves\" ");
                if (userSelect == "favorite city")
                {
                    Console.WriteLine($"{InputName}, loves the city {favoritecity}. ");
                }
                else if (userSelect == "pet peeves")
                {
                    Console.WriteLine($"{InputName}, really dislikes {petPeeves}. ");
                }

                else
                {
                    // So here in the else if the input was incorrect we inform the user
                    Console.WriteLine("Sorry, your entry was incorrect");
                    invalid = true;
                }

                Console.WriteLine($"Would you like to know more about {InputName}? y or n please? ");
                string userInput = Console.ReadLine().ToLower();

                //The user input is not equal to y and is not equal to n
                while (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Please enter y to keep going or press n to end the program. ");
                    userInput = Console.ReadLine().ToLower();
                }
                invalid = true;
                // User selects n, the loop will break
                if (userInput == "n")
                {
                    break;
                }
            }
        }
    }
}


     