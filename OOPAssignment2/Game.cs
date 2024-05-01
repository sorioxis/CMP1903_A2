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
        Console.WriteLine("4. View statistics");
        Console.WriteLine("5. Quit");
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
                if (!isValidChoice || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            } while (!isValidChoice || choice < 1 || choice > 5);

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
                    Console.WriteLine("Viewing statistics data:");
                    statistics.DisplayStats();
                    break;
                case 5:
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
        SevensOut sevensOut = new SevensOut();
        int sevensOutScore = sevensOut.Play();
        statistics.UpdateStats("Sevens Out", sevensOutScore);
        AskToPlaySevensOutAgain();
    }

    private void PlayThreeOrMore()
    {
        Console.WriteLine("Playing Three Or More...");
        ThreeOrMore threeOrMore = new ThreeOrMore(statistics);
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
            // Clear the console before restarting the game
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





