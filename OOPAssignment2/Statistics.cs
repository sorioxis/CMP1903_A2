using System;
using System.Collections.Generic;

public class Statistics
{
    private Dictionary<string, List<int>> stats;

    public Statistics()
    {
        stats = new Dictionary<string, List<int>>();
    }

    public void UpdateStats(string gameType, int score)
    {
        if (!stats.ContainsKey(gameType))
        {
            stats[gameType] = new List<int>();
        }
        stats[gameType].Add(score);
    }

    public void DisplayStats()
    {
        Console.WriteLine("Statistics:");
        foreach (var gameType in stats.Keys)
        {
            Console.WriteLine($"Game Type: {gameType}");
            Console.WriteLine($"Number of Plays: {stats[gameType].Count}");
            Console.WriteLine($"High-Scores: {string.Join(", ", stats[gameType])}");
            Console.WriteLine();
        }
    }
}

