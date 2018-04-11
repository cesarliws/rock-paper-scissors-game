using System;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            string[] rps = new string[3] { "r", "p", "s" };

            int randomNumber;

            Random ranNumberGenerator = new Random();
            randomNumber = ranNumberGenerator.Next(4);

            bool testCondition = true;

            while (testCondition)
            {
                Console.WriteLine("Enter r, p or c");
                inputString = Console.ReadLine();

                if (inputString != null && (inputString.Length == 1 && rps.Contains(inputString)))
                {
                    randomNumber = +ranNumberGenerator.Next(4);

                    if (rps[randomNumber].Equals(inputString))
                        Console.WriteLine("Draw");
                    else
                        Console.WriteLine("Lose");

                    testCondition = false;
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }

            }

            Console.Read();

        }
    }
}
