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
            string userInput;
            int score;
            int roundsCompleted = 4;
            int position = 0;

            // instantiate the random numbers and add them to the Simon numbers
            for (int i = 0; i < simonNumbers.Length; i++)
            {
                simonNumbers[i] = rnd.Next(1, 11);
            }



            //  while (roundsCompleted < simonNumbers.Length)
            //  {

            /*Console.WriteLine("Get Ready...");
            System.Threading.Thread.Sleep(2000); // delay
            Console.Clear();

                 // print simon numbers based on the roundscompleted
                for (int i = 0; i < roundsCompleted; i++)
                {
                    Console.WriteLine(simonNumbers[i]);
                System.Threading.Thread.Sleep(1000); // delay
                Console.Clear();
                }*/

            Console.WriteLine("Repeat the shown numbers (separate them by space)");
            userInput = Console.ReadLine();

            // split the user input by space
            /*for (int i = 0; i < userInput.Split(' ').Length; i++)
            {
                Console.WriteLine($"| {userInput.Split(' ')[i]} |");

            }*/

            // foreach loop to go through userInput array since the Split method turns the items entered into an array
            foreach (var enteredNumber in userInput.Split(' '))
            {
                Console.WriteLine($"| {enteredNumber} |");
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


            // }



        }
    }
}
