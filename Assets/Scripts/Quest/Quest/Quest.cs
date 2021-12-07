using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField]
    Info Information;

    [SerializeField]
    List<QuestGoal> Goals;

    [SerializeField]
    List<QuestReward> m_Rewards;
    
    public bool IsComplete { get; protected set; }
    public event EventHandler<QuestCompletedEvent> OnQuestCompleted;

    EventManager m_EventManager;
    IRewardable m_Awardable;

    [Serializable]
    public struct Info
    {
        public string Name;
        public Sprite Icon;
        public string Description;
    }

    public void Init(EventManager eventManager, IRewardable awardable)
    {
        m_EventManager = eventManager;
        m_Awardable = awardable;

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

    void GiveReward()
    {
        foreach (QuestReward questReward in m_Rewards)
        {
            questReward.Reward(m_Awardable);
        }
    }
}
