using UnityEngine;

public class CurrencyReward : QuestReward
{
    [SerializeField]
    int m_Amount = 1;

    public override string Description => $"{typeof(XPReward)}: {m_Amount}";

    public override void Reward(IRewardable awardable)
    {
        if (awardable is ICurrencyRewardable currencyBearing)
        {
            currencyBearing.RewardCurrency(m_Amount);
        }
    }
}
