using UnityEngine;

[CreateAssetMenu(fileName = "Goal", menuName = "Quest/Goals/Kill Goal")]
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
        KillEvent killEvent = gameEvent as KillEvent;

        if (killEvent == null) return;

        if (IsTargetID(killEvent))
            TargetKilled(killEvent);
    }

    void TargetKilled(KillEvent killEvent)
    {
        m_CurrentAmount++;
        Evaluate();
    }

    bool IsTargetID(KillEvent killEvent) => killEvent.ID == m_TargetID;   
}
