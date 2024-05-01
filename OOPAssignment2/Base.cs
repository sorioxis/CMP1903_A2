using System;

public abstract class GameBase
{
    protected Statistics statistics;

    public GameBase(Statistics stats)
    {
        statistics = stats;
    }

    public abstract int Play();
}


