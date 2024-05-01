using System;
using System.Collections.Generic;
/// <summary>
/// Keeps a statistical log of amount of plays for each individual game, and high scores for both.
/// </summary>
public class Statistics //New class 
{
    private Dictionary<string, List<int>> stats; //Stats is a dictionary - "keys" represent the game type. The integers are the high scores.

    public Statistics()
    {
        stats = new Dictionary<string, List<int>>(); //Initialise stats dictionary
    }

    public void UpdateStats(string gameType, int score) //Gametype for type of game, score for high scores
    {
        if (!stats.ContainsKey(gameType)) //String representing type of game (between SevensOut and ThreeOrMore)
        {
            stats[gameType] = new List<int>(); //Make a new list for the gametype
        }
        stats[gameType].Add(score);
    }

    public void DisplayStats() //Method to display stats when called from main menu
    {
        Console.WriteLine("Statistics:");
        foreach (var gameType in stats.Keys) //Iterate over key pair in the dictionary
        {
            Console.WriteLine($"Game Type: {gameType}"); //Print game type
            Console.WriteLine($"Number of Plays: {stats[gameType].Count}"); //Print amount of plays
            Console.WriteLine($"High-Scores: {string.Join(", ", stats[gameType])}"); //Print high scores
            Console.WriteLine();
        }
    }
}

