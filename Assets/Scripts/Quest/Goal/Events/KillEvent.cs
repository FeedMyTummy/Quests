public class KillEvent : GameEvent
{
    public readonly string ID;
    public override string Description => "Kill Event";

    public KillEvent(string id)
    {
        ID = id;
    }
}
