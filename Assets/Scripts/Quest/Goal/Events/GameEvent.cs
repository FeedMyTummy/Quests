using System;

public abstract class GameEvent : EventArgs
{
    public abstract string Description { get; }
}
