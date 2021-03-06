using UnityEngine;

public class QuestListener : MonoBehaviour, IXPRewardable, ICurrencyRewardable
{
    public void RewardXP(int amount)
    {
        Debug.Log($"XP Reward: {amount}");
    }

    public void RewardCurrency(int amount)
    {
        Debug.Log($"Currency Reward: {amount}");
    }
}
