using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class QuestManager : MonoBehaviour
{
    [SerializeField] List<Quest> m_Quests;
    [SerializeField] EventManager m_EventManager;
    [SerializeField] QuestListener m_QuestListener;

    public event EventHandler<AllQuestsCompletedEvent> OnAllQuestsCompleted;
    public bool AllQuestsComplete { get; set; }

    void Start()
    {
        foreach (Quest quest in m_Quests)
        {
            quest.Init(m_EventManager, m_QuestListener);
        }
    }

    void HandleQuestCompletion(object _, QuestCompletedEvent questCompletedEvent)
    {
        bool allQuestsCompleted = m_Quests.All( quest => quest.IsComplete );

        if (allQuestsCompleted)
            Complete();
    }

    void Complete()
    {
        AllQuestsComplete = true;
        OnAllQuestsCompleted?.Invoke(this, new AllQuestsCompletedEvent());
    }
    
    void OnEnable()
    {
        foreach (Quest quest in m_Quests)
        {
            quest.OnQuestCompleted += HandleQuestCompletion;
        }
    }

    void OnDisable()
    {
        foreach (Quest quest in m_Quests)
        {
            quest.OnQuestCompleted -= HandleQuestCompletion;
        }
    }
}
