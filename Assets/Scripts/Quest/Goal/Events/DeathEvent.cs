public class DeathEvent : GameEvent
{
    public readonly string DeadID;
    public readonly string InstigatorID;

    public DeathEvent(string deadID, string instigatorID)
    {
        DeadID = deadID;
        InstigatorID = instigatorID;
    }
}
