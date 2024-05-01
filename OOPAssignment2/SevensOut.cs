using System;
/// <summary>
/// SevensOut game according the brief. Follows these rules:
/// Sevens Out
///2 x dice
///Rules:
///Roll the two dice, noting the total rolled each time.
///If it is a 7 - stop.
///If it is any other number - add it to your total.
///If it is a double - add double the total to your score (3,3 would add 12 to your total)
///Has multiplayer functionality, first to get a 7 loses. Utilises inheritance from Base class.

/// </summary>
public class SevensOut : GameBase //Defines sevensout class, inherits from gamebase. Can override its methods (polymorphism)
{
    private Die die1; //These are from the Die class
    private Die die2;
    private bool isMultiplayer; //Declaring private bool fields - whether the game is multiplayer , and whether playing against computer or not.
    private bool playAgainstComputer;

    public SevensOut(bool isMultiplayer, bool playAgainstComputer, Statistics statistics) : base(statistics) //Constructor, take three params
    {
        die1 = new Die(); //New instance of Die class 
        die2 = new Die();
        this.isMultiplayer = isMultiplayer; //Initialises multiplayer and playing against computer fields
        this.playAgainstComputer = playAgainstComputer;
    }

    public override int Play() //Overrides Play from GameBase (polymorphism)
    {
        int total = 0; //Total score
        int roundTotal = 0; //Round score
        int round = 1; //Round number

        Console.WriteLine($"Starting Sevens Out...");
        Console.WriteLine("----------------------------------------");

        do //Execute game logic until break statement occurs
        {
            Console.WriteLine($"Round {round}:");
            if (isMultiplayer) //Different functionality for mutliplayer
            {
                Console.WriteLine("Player 1's Turn:");
                roundTotal = TakeTurn();
                total += roundTotal;
                Console.WriteLine($"Player 1's Current total: {total}");
                if (roundTotal == 7)
                {
                    Console.WriteLine("Player 1 rolled a 7! Player 1 loses.");
                    break;
                }
                Console.WriteLine("----------------------------------------");

                Console.WriteLine("Player 2's Turn:");
                roundTotal = TakeTurn();
                total += roundTotal;
                Console.WriteLine($"Player 2's Current total: {total}");
                if (roundTotal == 7)
                {
                    Console.WriteLine("Player 2 rolled a 7! Player 2 loses.");
                    break;
                }
                Console.WriteLine("----------------------------------------");
            }
            else //Singleplayer game logic
            {
                roundTotal = TakeTurn();
                total += roundTotal;
                Console.WriteLine($"Current total: {total}");

                if (roundTotal == 7)
                {
                    Console.WriteLine("You rolled a 7! Game Over.");
                    break;
                }

                Console.WriteLine("----------------------------------------");
            }

            round++; //Iterate over rounds
        } while (true);

        Console.WriteLine($"Final score: {total}");

        statistics.UpdateStats("Sevens Out", total); //Updates game statistics by called the updatestats method from the Statistics class.

        return total; //Returns total of game
    }

    private int TakeTurn() //Simulates taking a turn in the game
    {
        Console.WriteLine("Rolling the dice...");
        int roll1 = die1.Roll(); //Rolls die
        int roll2 = die2.Roll();
        Console.WriteLine($"Die 1: {roll1}, Die 2: {roll2}");

        int rollTotal = roll1 + roll2; //Roll total is both die added together
        Console.WriteLine($"Total: {rollTotal}");

        if (rollTotal == 7)
        {
            return rollTotal;
        }
        else
        {
            if (roll1 == roll2)
            {
                Console.WriteLine($"You rolled a double! Adding double the total to your score ({rollTotal * 2})."); //Double functionality
                return rollTotal * 2; //Doubles score
            }
            else
            {
                Console.WriteLine($"Adding the total ({rollTotal}) to your score.");
                return rollTotal;
            }
        }
    }
}














