using System;

public class SevensOut
{
    private Die die1;
    private Die die2;

    public SevensOut()
    {
        die1 = new Die();
        die2 = new Die();
    }

    public int Play()
    {
        int total = 0;
        int round = 1;

        do
        {
            Console.WriteLine($"Round {round}:");
            Console.WriteLine("Rolling the dice...");

            int roll1 = die1.Roll();
            int roll2 = die2.Roll();
            Console.WriteLine($"Die 1: {roll1}, Die 2: {roll2}");

            int rollTotal = roll1 + roll2;
            Console.WriteLine($"Total: {rollTotal}");

            if (rollTotal == 7)
            {
                Console.WriteLine("You rolled a 7! Game Over.");
                break;
            }
            else
            {
                total += rollTotal;
                Console.WriteLine($"Current total: {total}");

                if (die1.CurrentValue == die2.CurrentValue)
                {
                    total *= 2;
                    Console.WriteLine($"You rolled a double! Current total doubled to: {total}");
                }
            }

            
            Console.WriteLine("----------------------------------------");

            round++;
        }
        while (true);

        Console.WriteLine($"Final score: {total}");
        return total;
    }
}




