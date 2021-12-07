using System;
using UnityEngine;

public abstract class QuestGoal: ScriptableObject
{
    public abstract string Description { get; }
    public bool IsComplete => m_IsComplete;
    protected bool m_IsComplete;
    protected int m_CurrentAmount;
    protected int m_RequiredAmount = 1;
    EventManager m_EventManager;

    public event EventHandler<GoalCompletedEvent> OnGoalCompleted;

    public virtual void Init(EventManager eventManager)
    {
        m_CurrentAmount = 0;
        m_IsComplete = false;
        RemoveEventListener();
        
        m_EventManager = eventManager;
        m_EventManager.OnGameEvent += HandleGameEvent;;
    }

    protected void Evaluate()
    {
        if (IsGoalComplete())
            Complete();
    }

    bool IsGoalComplete() => m_CurrentAmount >= m_RequiredAmount;

    void Complete()
    {
        m_IsComplete = true;
        OnGoalCompleted?.Invoke(this, new GoalCompletedEvent());
        RemoveEventListener();
    }

    protected abstract void HandleGameEvent(object _, GameEvent gameEvent);

    void RemoveEventListener()
    {
        OnGoalCompleted = null;

        if (m_EventManager)
            m_EventManager.OnGameEvent -= HandleGameEvent;
    }
}
