using System;

public class Die
{
    private Random random;
    public int CurrentValue { get; private set; }

    public Die()
    {
        random = new Random();
        CurrentValue = 0;
    }

    public int Roll()
    {
        CurrentValue = random.Next(1, 7);
        return CurrentValue;
    }
}