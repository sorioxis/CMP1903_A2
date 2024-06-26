﻿using System;
using System.Diagnostics;
/// <summary>
/// Testing class. Allows for the testing of sevensout and threeormore, as per the requirements of the brief.
/// It will test rolls, ending scores, score calculations. Any errors will be asserted. If the tests pass, the user will be informed through the console.
/// </summary>
internal class Testing //Define a new testing class
{
    public static void TestSevensOut() //Method for testing sevensout, we dont call the method from another class for isolated testing
    {
        Debug.WriteLine("Running tests for Sevens Out...");

        int totalRolls = 0; //Track information about rolls for testing
        int rollSum = 0;
        bool firstRoll = true;
        bool allRollsValid = true;

        Console.WriteLine("Rolls:");

        Die die = new Die();  //New die instance

        while (rollSum != 7 || firstRoll) //While loop until roll sum is equal to 7 and is not the first roll.
        {
            int roll1 = die.Roll(); //Rolls the two die
            int roll2 = die.Roll(); 

            rollSum = roll1 + roll2;
            totalRolls += rollSum;

            Console.WriteLine($"Die 1: {roll1}, Die 2: {roll2}, Total: {rollSum}");

            if (!firstRoll) //Checks whether it is the first roll
            {
                allRollsValid &= TestingSevensOutRollSum(rollSum); //Utilises testing method to check sum is correct
            }
            else
            {
                firstRoll = false;
            }
        }

        bool isSeven = rollSum == 7; //Asserts roll sum is equal to 7 when game ends
        Debug.Assert(isSeven, $"Test Failed: Ending on a {rollSum}, expected 7.");

        if (isSeven) //Passing test code
        {
            Console.WriteLine("Test Passed: Ending on a 7");
        }
        else
        {
            Console.WriteLine($"Test Failed: Ending on a {rollSum}, expected 7");
        }

        bool isValidSum = allRollsValid; //Assserts roll sum is between 2 and 12
        Debug.Assert(isValidSum, "Test Failed: Not all rolls are between 2 and 12.");

        if (isValidSum)
        {
            Console.WriteLine("Test Passed: All rolls are between 2 and 12");
        }
        else
        {
            Console.WriteLine("Test Failed: Not all rolls are between 2 and 12");
        }

        Debug.WriteLine("Sevens Out tests completed.");
    }

    public static void TestThreeOrMore() //Method for testing threeormore
    {
        Debug.WriteLine("Running tests for Three Or More...");

        int totalScore = 0;
        int round = 1;
        int previousScore = 0;

        while (totalScore <= 20) //Loop continues until total score is 20 or more
        {
            Console.WriteLine($"Round {round}:");
            Console.WriteLine("Rolling the dice...");
            Die die = new Die(); //New die instance
            int[] dice = new int[5]; //Declare array to store dice value
            for (int i = 0; i < 5; i++) //Roll five die
            {
                dice[i] = die.Roll();
            }
            Console.WriteLine($"Dice: {string.Join(", ", dice)}");

            int score = CalculateScore(dice); //Calls calculate score method
            Console.WriteLine($"Score for this round: {score}");

            //Assert for incorrect score calculation
            Debug.Assert(totalScore == previousScore + score, $"Test Failed: Incorrect score calculation for round {round}");

            totalScore += score;
            previousScore = totalScore;
            Console.WriteLine($"Total score: {totalScore}");
            round++; //Iterate over round

            Console.WriteLine("----------------------------------------");
        }
        //Asserts ending score is 20 or greater
        Debug.Assert(totalScore >= 20, $"Test Failed: Total score is less than 20.");

        Console.WriteLine("Test Passed: Total score reached 20 or more.");

        Debug.WriteLine("Three Or More tests completed.");
    }

    private static bool TestingSevensOutRollSum(int rollSum) //Method for checking roll sum between 2-12
    {
        return rollSum >= 2 && rollSum <= 12; //Returns true if roll sum is between 2 and 12
    }

    private static int CalculateScore(int[] dice) //Calculate score logic 
    {
        int score = 0;

        int[] counts = new int[6];
        foreach (int die in dice)
        {
            counts[die - 1]++;
        }

        bool hasThreeOfAKind = false;
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
            else if (counts[i] >= 3 && !hasThreeOfAKind)
            {
                int ofAKind = i + 1;
                Console.WriteLine($"3 of a kind detected - {ofAKind}. Bonus points added: 3");
                score += 3;
                hasThreeOfAKind = true;
            }
        }

        if (!hasFiveOfAKind && !hasFourOfAKind && !hasThreeOfAKind)
        {
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
                                Die newDie = new Die();
                                dice[j] = newDie.Roll();
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

















