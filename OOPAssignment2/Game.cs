using System;
/// <summary>
/// Main game classes. This contains the main menu and most of the error handling logic, as well as game replaying logic.
/// It also handles actually launching the program.
/// </summary>
/// <returns>
/// Main menu, game of the players choosing
/// </returns>
public class Game //New game class containing private statistics field
{
    private Statistics statistics; 

    public Game() //Constructor, intitialises statistics 
    {
        statistics = new Statistics(); //New instance
    }

    public void Menu() //Main menu, user can choose between these options. error handling is done in Run method
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

    public void Run() //Main loop of game
    {
        bool quit = false; //Loop continues until user decides to quit menu
        do
        {
            Menu();
            int choice;
            bool isValidChoice; //Needs to be a valid choice
            do
            {
                Console.WriteLine("Enter your choice: ");
                string input = Console.ReadLine(); //Reads user input
                isValidChoice = int.TryParse(input, out choice); //Will try to parse input
                if (!isValidChoice || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                }
            } while (!isValidChoice || choice < 1 || choice > 6); //Error handling

            switch (choice) //Contains a bunch of methods that will be called depending on user choice.
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

        } while (!quit); //Will do this until quit 
    }

    private void PlaySevensOut() //Method for launching SevensOut
    {
        Console.WriteLine("Playing Sevens Out...");

        Console.WriteLine("Would you like to play in Multiplayer mode? (yes/no)");
        string multiplayerInput = Console.ReadLine().ToLower(); //Makes all user input lowercase

        bool isMultiplayer = multiplayerInput == "yes"; //Sets bool flag to true if yes

        bool playAgainstComputer = false; //Bool flag for playing against computer

        if (isMultiplayer) //If the previous bool flag is true, then run below code
        {
            Console.WriteLine("Would you like to play against a friend or a computer? (friend/computer)");
            string opponentInput = Console.ReadLine().ToLower(); 
            playAgainstComputer = opponentInput == "computer"; //Set playagainstcomputer to true if user chooses 
        }

        SevensOut sevensOut = new SevensOut(isMultiplayer, playAgainstComputer, statistics); //Creates sevensout instance, passing multiplayer & choice as params
        sevensOut.Play(); //Call play method to start the game

        AskToPlaySevensOutAgain(); //Calls ask to play again method
    }

    private void PlayThreeOrMore() //Method for launching ThreeOrMore
    {
        Console.WriteLine("Playing Three Or More...");

        Console.WriteLine("Would you like to play in Multiplayer mode? (yes/no)");
        string multiplayerInput = Console.ReadLine().ToLower();

        bool isMultiplayer = multiplayerInput == "yes"; //Multiplayer flag, same as before

        ThreeOrMore threeOrMore = new ThreeOrMore(statistics, isMultiplayer); //Passes parameters
        threeOrMore.Play(); //Calls play method
        AskToPlayThreeOrMoreAgain(); //Calls retry method
    }

    private void AskToPlaySevensOutAgain() //Method for asking user to retry sevensout
    {
        Console.WriteLine("Would you like to play Sevens Out again? (yes/no)");
        string input = Console.ReadLine().ToLower();
        if (input == "yes") //Restarts sevensout
        {
            Console.WriteLine("Restarting Sevens Out...");
            Console.Clear(); //Clears console for readability
            PlaySevensOut(); //Calls method from above
        }
        else if (input == "no") //Returns to main menu if no
        {
            Console.WriteLine("Returning to main menu...");
        }
        else //Will return to main menu if invalid input
        {
            Console.WriteLine("Invalid input. Returning to main menu...");
        }
    }

    private void AskToPlayThreeOrMoreAgain() //Method for asking user to retry ThreeOrMore
    {
        Console.WriteLine("Would you like to play Three Or More again? (yes/no)");
        string input = Console.ReadLine().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("Restarting Three Or More...");
            Console.Clear(); //Clears console
            PlayThreeOrMore(); //Calls above method
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

    public static void Main(string[] args) //Entry point of the program, required in assignment brief
    {
        Game game = new Game(); //New instance of game class
        game.Run(); //Calls run method
    }
}





