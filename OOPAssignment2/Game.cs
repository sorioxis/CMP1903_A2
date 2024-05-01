using System;

public class Game
{
    private Statistics statistics;

    public Game()
    {
        statistics = new Statistics();
    }

    public void Menu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1. Play Sevens Out");
        Console.WriteLine("2. Play Three Or More");
        Console.WriteLine("3. Test Sevens Out");
        Console.WriteLine("4. Test Three Or More");
        Console.WriteLine("5. View statistics");
        Console.WriteLine("6. Quit");
        Console.WriteLine("----------------------------------------");
    }

    public void Run()
    {
        bool quit = false;
        do
        {
            Menu();
            int choice;
            bool isValidChoice;
            do
            {
                Console.WriteLine("Enter your choice: ");
                string input = Console.ReadLine();
                isValidChoice = int.TryParse(input, out choice);
                if (!isValidChoice || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                }
            } while (!isValidChoice || choice < 1 || choice > 6);

            switch (choice)
            {
                case 1:
                    PlaySevensOut();
                    break;
                case 2:
                    PlayThreeOrMore();
                    break;
                case 3:
                    Console.WriteLine("Testing Sevens Out...");
                    Testing.TestSevensOut();
                    break;
                case 4:
                    Console.WriteLine("Testing Three Or More...");
                    Testing.TestThreeOrMore();
                    break;
                case 5:
                    Console.WriteLine("Viewing statistics data:");
                    statistics.DisplayStats();
                    break;
                case 6:
                    quit = true;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (!quit);
    }

    private void PlaySevensOut()
    {
        Console.WriteLine("Playing Sevens Out...");

        Console.WriteLine("Would you like to play in Multiplayer mode? (yes/no)");
        string multiplayerInput = Console.ReadLine().ToLower();

        bool isMultiplayer = multiplayerInput == "yes";

        bool playAgainstComputer = false;

        if (isMultiplayer)
        {
            Console.WriteLine("Would you like to play against a friend or a computer? (friend/computer)");
            string opponentInput = Console.ReadLine().ToLower();
            playAgainstComputer = opponentInput == "computer";
        }

        SevensOut sevensOut = new SevensOut(isMultiplayer, playAgainstComputer, statistics);
        sevensOut.Play();

        AskToPlaySevensOutAgain();
    }

    private void PlayThreeOrMore()
    {
        Console.WriteLine("Playing Three Or More...");

        Console.WriteLine("Would you like to play in Multiplayer mode? (yes/no)");
        string multiplayerInput = Console.ReadLine().ToLower();

        bool isMultiplayer = multiplayerInput == "yes";

        ThreeOrMore threeOrMore = new ThreeOrMore(statistics, isMultiplayer);
        int threeOrMoreScore = threeOrMore.Play();
        statistics.UpdateStats("Three Or More", threeOrMoreScore);

        AskToPlayThreeOrMoreAgain();
    }

    private void AskToPlaySevensOutAgain()
    {
        Console.WriteLine("Would you like to play Sevens Out again? (yes/no)");
        string input = Console.ReadLine().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("Restarting Sevens Out...");
            Console.Clear();
            PlaySevensOut();
        }
        else if (input == "no")
        {
            Console.WriteLine("Returning to main menu...");
        }
        else
        {
            Console.WriteLine("Invalid input. Returning to main menu...");
        }
    }

    private void AskToPlayThreeOrMoreAgain()
    {
        Console.WriteLine("Would you like to play Three Or More again? (yes/no)");
        string input = Console.ReadLine().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("Restarting Three Or More...");
            Console.Clear();
            PlayThreeOrMore();
        }
        else if (input == "no")
        {
            Console.WriteLine("Returning to main menu...");
        }
        else
        {
            Console.WriteLine("Invalid input. Returning to main menu...");
        }
    }

    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Run();
    }
}





