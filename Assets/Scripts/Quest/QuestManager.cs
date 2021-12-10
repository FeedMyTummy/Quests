using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    List<Quest> m_Quests;

    [SerializeField]
    EventManager m_EventManager;

    [SerializeField]
    QuestListener m_QuestListener;
    
    void Start()
    {
        foreach (Quest quest in m_Quests)
        {
            quest.Init(m_EventManager, m_QuestListener);
        }
    }
}
