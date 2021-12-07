using UnityEngine;

public abstract class QuestReward: MonoBehaviour
{
    public abstract string Description { get; }

    public abstract void Reward(IRewardable awardable);
}