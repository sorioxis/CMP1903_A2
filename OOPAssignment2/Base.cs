using System;
/// <summary>
/// Provides general structure for playing our SevensOut game - it can build off of this as a subclass.
/// </summary>
public abstract class GameBase //New abstract class to be used for inheritance / polymorphism in the SevensOut class - defining a blueprint to be built on
{
    protected Statistics statistics; //Protected, accessible from this class and its derived classes

    public GameBase(Statistics stats) //Constructor
    {
        statistics = stats;
    }

    public abstract int Play(); //Declares abstract method 
}


