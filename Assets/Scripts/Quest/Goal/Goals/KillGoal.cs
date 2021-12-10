using UnityEngine;

public sealed class KillGoal : QuestGoal
{
    [SerializeField]
    string m_TargetID;

    [SerializeField]
    string m_Description;

    [SerializeField]
    int m_AmountToKill = 1;

    public override string Description => m_Description;

    public override void Init(EventManager eventManager)
    {
        base.Init(eventManager);
        m_RequiredAmount = m_AmountToKill;
    }

    protected override void HandleGameEvent(object _, GameEvent gameEvent)
    {
        DeathEvent deathEvent = gameEvent as DeathEvent;

        if (deathEvent == null) return;

        if (IsTargetID(deathEvent))
            TargetKilled();
    }

    void TargetKilled()
    {
        m_CurrentAmount++;
        Evaluate();
    }

    bool IsTargetID(DeathEvent deathEvent) => deathEvent.DeadID == m_TargetID;   
}
