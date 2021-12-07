using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    Quest m_Quest;

    [SerializeField]
    EventManager m_EventManager;

    [SerializeField]
    Player m_Player;
    
    void Start()
    {
        m_Quest.Init(m_EventManager, m_Player);
    }
}
