using System;

public class ThreeOrMore
{
    private Statistics statistics;
    private bool isMultiplayer;

    public ThreeOrMore(Statistics stats, bool isMultiplayer)
    {
        statistics = stats;
        this.isMultiplayer = isMultiplayer;
    }

    public int Play()
    {
        int totalScorePlayer1 = 0;
        int totalScorePlayer2 = 0;
        int round = 1;

        while (true)
        {
            Console.WriteLine($"Round {round}:");

            
            Console.WriteLine("Player 1's Turn:");
            totalScorePlayer1 += TakeTurn();
            Console.WriteLine($"Player 1's Total Score: {totalScorePlayer1}");

            if (totalScorePlayer1 >= 20)
            {
                Console.WriteLine("Player 1 Wins!");
                return totalScorePlayer1;
            }

            Console.WriteLine("----------------------------------------");

            if (isMultiplayer)
            {
                
                Console.WriteLine("Player 2's Turn:");
                totalScorePlayer2 += TakeTurn();
                Console.WriteLine($"Player 2's Total Score: {totalScorePlayer2}");

                if (totalScorePlayer2 >= 20)
                {
                    Console.WriteLine("Player 2 Wins!");
                    return totalScorePlayer2;
                }

                Console.WriteLine("----------------------------------------");
            }

            round++;
        }
    }

    private int TakeTurn()
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

    private int CalculateScore(int[] dice)
    {
        int score = 0;

        int[] counts = new int[6];
        foreach (int die in dice)
        {
            counts[die - 1]++;
        }

        bool hasThreeOrMoreOfAKind = false;
        bool hasFourOfAKind = false;
        bool hasFiveOfAKind = false;

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] >= 5)
            {
                int ofAKind = i + 1;
                Console.WriteLine($"5 of a kind detected - {ofAKind}. Bonus points added: 12");
                score += 12;
                hasFiveOfAKind = true;
            }
            else if (counts[i] >= 4 && !hasFourOfAKind)
            {
                int ofAKind = i + 1;
                Console.WriteLine($"4 of a kind detected - {ofAKind}. Bonus points added: 6");
                score += 6;
                hasFourOfAKind = true;
            }
            else if (counts[i] >= 3 && !hasThreeOrMoreOfAKind)
            {
                int ofAKind = i + 1;
                Console.WriteLine($"3 of a kind detected - {ofAKind}. Bonus points added: 3");
                score += 3;
                hasThreeOrMoreOfAKind = true;
            }
        }

        if (!hasFiveOfAKind && !hasFourOfAKind && !hasThreeOrMoreOfAKind)
        {
            int twoOfAKindValue = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] >= 2)
                {
                    int ofAKind = i + 1;
                    Console.WriteLine($"2 of a kind detected - {ofAKind}. Choose option:");
                    Console.WriteLine("1. Rethrow all");
                    Console.WriteLine("2. Throw remaining dice");
                    int choice;
                    do
                    {
                        Console.Write("Enter your choice: ");
                    } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2));

                    if (choice == 1)
                    {
                        Console.WriteLine("Rethrowing all dice...");
                        Die newDie = new Die();
                        for (int j = 0; j < dice.Length; j++)
                        {
                            dice[j] = newDie.Roll();
                        }
                        Console.WriteLine($"New dice sequence: {string.Join(", ", dice)}");
                        return CalculateScore(dice);
                    }
                    else
                    {
                        Console.WriteLine("Throwing remaining dice...");
                        for (int j = 0; j < dice.Length; j++)
                        {
                            if (dice[j] != ofAKind)
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

        return score;
    }
}

