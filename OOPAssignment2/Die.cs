using System;
/// <summary>
/// Die class that has methods that will be called throughout our entire program - generates random number between 0 and 7 (1-6).
/// </summary>
/// <returns>
/// Number generated between 1 and 6
/// </returns>
public class Die //New class definition
{
    private Random random; //Can only be accessed by this class
    public int CurrentValue { get; private set; } //As per the brief, property that holds the current die value. Can only be set within this class.

    public Die() //Constructor method
    {
        random = new Random(); //Initialise random method
        CurrentValue = 0; //Current value is 0
    }

    public int Roll() //Method that will be utilised across the entire program, for rolling our die
    {
        CurrentValue = random.Next(1, 7); //Generate a random number 1-6
        return CurrentValue; //Update current value with generated number and return it
    }
}