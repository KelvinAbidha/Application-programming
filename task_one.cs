using System;

class LuckyGame
{
    static void Main()
    {
        int secretNumber = 7; 
        int totalScore = 0;

        Console.Write("Enter number of rounds: ");
        int rounds = int.Parse(Console.ReadLine());

        for (int i = 0; i < rounds; i++)
        {
            Console.Write("Enter your lucky number: ");
            int luckyNumber = int.Parse(Console.ReadLine());

            int remainder = luckyNumber % secretNumber;

            if (remainder == 0)
            {
                totalScore += 1; // Draw
            }
            else if (remainder % 2 == 0)
            {
                totalScore += 3; // Win
            }
            else
            {
                totalScore -= 3; // Loss
            }
        }

        if (totalScore > 0)
        {
            Console.WriteLine("Congratulations! You won with a score of " + totalScore);
        }
        else
        {
            Console.WriteLine("You lost. Your final score is " + totalScore);
        }
    }
}