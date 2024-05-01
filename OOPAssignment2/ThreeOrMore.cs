using System;

public class ThreeOrMore
{
    private Statistics statistics;

    public ThreeOrMore(Statistics stats)
    {
        statistics = stats;
    }

    public int Play()
    {
        int totalScore = 0;
        int round = 1;

        while (totalScore < 20)
        {
            Console.WriteLine($"Round {round}:");
            Console.WriteLine("Rolling the dice...");
            int[] dice = RollDice();
            Console.WriteLine($"Dice: {string.Join(", ", dice)}");

            int score = CalculateScore(dice);
            Console.WriteLine($"Score for this round: {score}");

            totalScore += score;
            Console.WriteLine($"Total score: {totalScore}");

            round++;
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine("You've reached a total score of 20 or more! Game Over.");
        return totalScore;
    }

    private int[] RollDice()
    {
        Die[] dice = new Die[5];
        for (int i = 0; i < 5; i++)
        {
            dice[i] = new Die();
        }

        int[] values = new int[5];
        for (int i = 0; i < 5; i++)
        {
            values[i] = dice[i].Roll();
        }
        return values;
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
                        dice = RollDice();
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