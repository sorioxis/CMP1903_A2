using System;

public class SevensOut : GameBase
{
    private Die die1;
    private Die die2;
    private bool isMultiplayer;
    private bool playAgainstComputer;

    public SevensOut(bool isMultiplayer, bool playAgainstComputer, Statistics statistics) : base(statistics)
    {
        die1 = new Die();
        die2 = new Die();
        this.isMultiplayer = isMultiplayer;
        this.playAgainstComputer = playAgainstComputer;
    }

    public override int Play()
    {
        int total = 0;
        int roundTotal = 0;
        int round = 1;

        Console.WriteLine($"Starting Sevens Out...");
        Console.WriteLine("----------------------------------------");

        do
        {
            Console.WriteLine($"Round {round}:");
            roundTotal = TakeTurn();
            total += roundTotal;
            Console.WriteLine($"Current total: {total}");

            if (roundTotal == 7)
            {
                Console.WriteLine("You rolled a 7! Game Over.");
                break;
            }

            Console.WriteLine("----------------------------------------");
            round++;
        }
        while (true);

        Console.WriteLine($"Final score: {total}");

        statistics.UpdateStats("Sevens Out", total);

        return total;
    }

    private int TakeTurn()
    {
        Console.WriteLine("Rolling the dice...");
        int roll1 = die1.Roll();
        int roll2 = die2.Roll();
        Console.WriteLine($"Die 1: {roll1}, Die 2: {roll2}");

        int rollTotal = roll1 + roll2;
        Console.WriteLine($"Total: {rollTotal}");

        if (rollTotal == 7)
        {
            return rollTotal;
        }
        else
        {
            if (roll1 == roll2)
            {
                Console.WriteLine($"You rolled a double! Adding double the total to your score ({rollTotal * 2}).");
                return rollTotal * 2;
            }
            else
            {
                Console.WriteLine($"Adding the total ({rollTotal}) to your score.");
                return rollTotal;
            }
        }
    }
}














