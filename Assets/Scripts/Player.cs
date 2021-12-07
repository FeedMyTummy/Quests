using UnityEngine;

public class Player : MonoBehaviour, IAwardable
{
    public void Award(QuestReward reward)
    {
        Debug.Log($"Rewarded: {reward.Description}");
    }
}
