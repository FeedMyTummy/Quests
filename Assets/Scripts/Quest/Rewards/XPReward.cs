using UnityEngine;

public sealed class XPReward : QuestReward
{
    [SerializeField]
    int m_Amount = 1;

    public override string Description => $"{typeof(XPReward)}: {m_Amount}";

    public override void Reward(IRewardable awardable)
    {
        if (awardable is IXPRewardable xpBearing)
        {
            xpBearing.RewardXP(m_Amount);
        }
    }
}