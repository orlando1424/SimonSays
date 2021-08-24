using System;

namespace SimonSays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] simonNumbers = new int[12];
            int[] userNumbers = new int[12];
            Random rnd = new Random();
            bool error = false;
            bool incorrectValue = false;
            string userInput;
            int score = 0;
            int roundsCompleted = 1;
           

            // instantiate the random numbers and add them to the Simon numbers
            for (int i = 0; i < simonNumbers.Length; i++)
            {
                simonNumbers[i] = rnd.Next(1, 13);
            }



            while (roundsCompleted <= simonNumbers.Length)
            {

                Console.WriteLine("Get Ready...");
                System.Threading.Thread.Sleep(2000); // delay
                Console.Clear();

                // print simon numbers based on the roundscompleted
                for (int i = 0; i < roundsCompleted; i++)
                {
                    Console.WriteLine(simonNumbers[i]);
                    System.Threading.Thread.Sleep(1000); // delay
                    Console.Clear();
                }
                // ask for the user input 
                Console.WriteLine("Repeat the shown numbers (separate them by space)");
                userInput = Console.ReadLine();


                int position = 0;
                error = false;
                // foreach loop to go through userInput array since the Split method turns the items entered into an array
                foreach (string enteredNumber in userInput.Split(' '))
                {
                    Console.WriteLine($"Number {position + 1}: {enteredNumber} ");
                    // if it is not a number 
                    if (!int.TryParse(enteredNumber, out userNumbers[position]))
                    {
                        Console.WriteLine($"Non number entered! error in {position + 1}");
                        error = true;
                        break;
                    }
                    position++;

                    if (position == roundsCompleted)
                    {
                        break;
                    }
                }

                if (position < roundsCompleted)
                {
                    Console.WriteLine("Too few items entered.");
                    error = true;
                }

                if (!error)
                {
                 

                    // compare the entered user values to the simon values 
                 
                    for (int i = 0; i < roundsCompleted; i++)
                    {
                        if (simonNumbers[i] != userNumbers[i])
                        {
                            incorrectValue = true;
                            break;
                        }
                    }

                    if (incorrectValue)
                    {
                        Console.WriteLine("You failed to repeat all numbers, you lose! ");
                        Console.WriteLine($"The correct number was {simonNumbers[position - 1]}");
                        Console.WriteLine($"Here is your score {score}");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Good, next round...");
                        System.Threading.Thread.Sleep(1000); // Delay 
                        roundsCompleted++;
                        score++;
                    }
                }
                // checks if the user got all numbers from simon correct 
                if (roundsCompleted == simonNumbers.Length)
                {
                    Console.WriteLine("You beat Simon!");
                }

            }



        }
    }
}
