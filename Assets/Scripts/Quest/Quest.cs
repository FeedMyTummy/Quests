using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    [Header("Info"), SerializeField]
    Info Information;

    [Header("Reward"), SerializeField]
    QuestReward m_Reward;
    
    public bool IsComplete { get; protected set; }
    public event EventHandler<QuestCompletedEvent> OnQuestCompleted;

    [SerializeField]
    List<QuestGoal> Goals;

    EventManager m_EventManager;
    IAwardable m_Awardable;

    [Serializable]
    public struct Info
    {
        public string Name;
        public Sprite Icon;
        public string Description;
    }

    public void Init(EventManager eventManager, IAwardable awardable)
    {
        m_EventManager = eventManager;
        m_Awardable = awardable;

        IsComplete = false;
        OnQuestCompleted = null;

        foreach (QuestGoal goal in Goals)
        {
            goal.Init(m_EventManager);
            goal.OnGoalCompleted += HandleGoalCompletedEvent;
        }
    }

     void HandleGoalCompletedEvent(object _, GoalCompletedEvent completionEvent)
    {
        bool allGoalsCompleted = Goals.All( goal => goal.IsComplete );

        if (allGoalsCompleted)
            Complete();
    }

    void Complete()
    {
        IsComplete = true;
        GiveReward();
        
        OnQuestCompleted?.Invoke(this, new QuestCompletedEvent());
        OnQuestCompleted = null;
    }

    void GiveReward() => m_Awardable.Award(m_Reward);
}
