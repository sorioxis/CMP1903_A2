using System;
/// <summary>
/// Three Or More game class. Has multiplayer functionality. In the future, inheritance should be used just like SevensOut.
/// Works according to the brief requirement rules:
/// Three or More
///5 x dice
///Rules:
///Roll all 5 dice hoping for a 3-of-a-kind or better.
///If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
///3-of-a-kind: 3 points
///4-of-a-kind: 6 points
///5-of-a-kind: 12 points
///First to a total of 20.
/// </summary>
public class ThreeOrMore //Define threeormoreclass
{
    private int totalScore; //Private fields, stores total score, multiplayer indicator and statistics
    private bool isMultiplayer;
    private Statistics statistics;

    public ThreeOrMore(Statistics stats, bool isMultiplayer) //Constructor to initalise fields
    {
        this.isMultiplayer = isMultiplayer;
        statistics = stats;
    }

    public int Play() //Method to start playing the game - could be inhereted from GameBase in the future
    {
        int totalScorePlayer1 = 0; //Total scores for multiplayer functionality
        int totalScorePlayer2 = 0;
        int round = 1; //Round counter

        Console.WriteLine($"Starting Three Or More{(isMultiplayer ? " in Multiplayer mode" : " in Singleplayer mode")}...");
        Console.WriteLine("----------------------------------------");

        while (true) //Infinite loop until game ends
        {
            Console.WriteLine($"Round {round}:");

            Console.WriteLine("Player 1's Turn:");
            totalScorePlayer1 += TakeTurn();
            Console.WriteLine($"Player 1's Total Score: {totalScorePlayer1}");

            if (totalScorePlayer1 >= 20) //If score is more or equal to 20, end game
            {
                Console.WriteLine("Player 1 Wins!");
                totalScore = totalScorePlayer1;
                statistics.UpdateStats("Three Or More", totalScorePlayer1);
                return totalScore; 
            }

            Console.WriteLine("----------------------------------------");

            if (isMultiplayer) //Different logic if the game is multiplayer
            {
                Console.WriteLine("Player 2's Turn:");
                totalScorePlayer2 += TakeTurn();
                Console.WriteLine($"Player 2's Total Score: {totalScorePlayer2}");

                if (totalScorePlayer2 >= 20)
                {
                    Console.WriteLine("Player 2 Wins!");
                    totalScore = totalScorePlayer2;
                    statistics.UpdateStats("Three Or More", totalScorePlayer2); 
                    return totalScore; 
                }

                Console.WriteLine("----------------------------------------");
            }

            round++;
        }
    }

    public int GetTotalScore() //Method to retrieve total score, used for testing purposes
    {
        return totalScore;
    }

    private int TakeTurn() //Method for simulating rolling 5 die
    {
        Console.WriteLine("Rolling the dice...");
        Die die = new Die();
        int[] dice = new int[5];
        for (int i = 0; i < 5; i++)
        {
            dice[i] = die.Roll();
        }
        Console.WriteLine($"Dice: {string.Join(", ", dice)}");

        int score = CalculateScore(dice);
        Console.WriteLine($"Score for this round: {score}");

        return score;
    }

    private int CalculateScore(int[] dice) //Calculating score method
    {
        int score = 0; //Score for current round

        int[] counts = new int[6]; //Array for counting how many times a die number has appearead
        foreach (int die in dice)
        {
            counts[die - 1]++; //Iterates over array to check for of a kinds
        }

        bool hasThreeOrMoreOfAKind = false; //Boolean flags for checking of a kinds
        bool hasFourOfAKind = false;
        bool hasFiveOfAKind = false;

        for (int i = 0; i < counts.Length; i++) //Of a kind logic
        {
            if (counts[i] >= 5) //Five of a kind logic
            {
                int ofAKind = i + 1;
                Console.WriteLine($"5 of a kind detected - {ofAKind}. Bonus points added: 12");
                score += 12;
                hasFiveOfAKind = true;
            }
            else if (counts[i] >= 4 && !hasFourOfAKind) //Four of a kind logic
            {
                int ofAKind = i + 1;
                Console.WriteLine($"4 of a kind detected - {ofAKind}. Bonus points added: 6");
                score += 6;
                hasFourOfAKind = true;
            }
            else if (counts[i] >= 3 && !hasThreeOrMoreOfAKind) //Three of a kind logic
            {
                int ofAKind = i + 1;
                Console.WriteLine($"3 of a kind detected - {ofAKind}. Bonus points added: 3");
                score += 3;
                hasThreeOrMoreOfAKind = true;
            }
        }

        if (!hasFiveOfAKind && !hasFourOfAKind && !hasThreeOrMoreOfAKind) //Handles two of a kind logic where there is no other of a kind combinations
        {
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] >= 2) //Determines die face value 
                {
                    int ofAKind = i + 1; //Allows the user to rethrow all die or just remaining
                    Console.WriteLine($"2 of a kind detected - {ofAKind}. Choose option:");
                    Console.WriteLine("1. Rethrow all");
                    Console.WriteLine("2. Throw remaining dice");
                    int choice;
                    do
                    {
                        Console.Write("Enter your choice: ");
                    } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2)); //Error handling

                    if (choice == 1)
                    {
                        Console.WriteLine("Rethrowing all dice...");
                        Die newDie = new Die(); //New die instance to simulate rolling again
                        for (int j = 0; j < dice.Length; j++) //Iterates over each element, new random value
                        {
                            dice[j] = newDie.Roll();
                        }
                        Console.WriteLine($"New dice sequence: {string.Join(", ", dice)}");
                        return CalculateScore(dice); //Calls method to calculate score
                    }
                    else
                    {
                        Console.WriteLine("Throwing remaining dice...");
                        for (int j = 0; j < dice.Length; j++) //Iterates over each element again
                        {
                            if (dice[j] != ofAKind) //If iterated over die value is not equal to two of a kind combination , reroll
                            {
                                dice[j] = new Die().Roll();
                            }
                        }
                        Console.WriteLine($"New dice sequence: {string.Join(", ", dice)}");
                        score += CalculateScore(dice);
                        break;
                    }
                }
            }
        }

        return score; //Return total score for round
    }
}




