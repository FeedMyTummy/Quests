public class KillEvent : GameEvent
{
    public readonly string DeadID;
    public readonly string InstigatorID;

    public KillEvent(string deadID, string instigatorID)
    {
        DeadID = deadID;
        InstigatorID = instigatorID;
    }
}
