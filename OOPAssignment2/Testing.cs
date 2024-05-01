using System;
using System.Diagnostics;

internal class Testing
{
    public static void TestSevensOut()
    {
        Debug.WriteLine("Running tests for Sevens Out...");

        int totalRolls = 0;
        int rollSum = 0;
        bool firstRoll = true;
        bool allRollsValid = true;

        Console.WriteLine("Rolls:");

        while (rollSum != 7 || firstRoll)
        {
            int roll1 = RollDie();
            int roll2 = RollDie();

            rollSum = roll1 + roll2;
            totalRolls += rollSum;

            Console.WriteLine($"Die 1: {roll1}, Die 2: {roll2}, Total: {rollSum}");

            if (!firstRoll)
            {
                allRollsValid &= TestingSevensOutRollSum(rollSum);
            }
            else
            {
                firstRoll = false;
            }
        }

        bool isSeven = rollSum == 7;
        Debug.Assert(isSeven, $"Test Failed: Ending on a {rollSum}, expected 7.");

        if (isSeven)
        {
            Console.WriteLine("Test Passed: Ending on a 7");
        }
        else
        {
            Console.WriteLine($"Test Failed: Ending on a {rollSum}, expected 7");
        }

        bool isValidSum = allRollsValid;
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

    private static int RollDie()
    {
        return new Random().Next(1, 7);
    }

    private static bool TestingSevensOutRollSum(int rollSum)
    {
        return rollSum >= 2 && rollSum <= 12;
    }
}



















