using UnityEngine;

[CreateAssetMenu(fileName = "XPReward", menuName = "Quest/Rewards/XP Reward")]
public sealed class XPReward : QuestReward
{
    [SerializeField]
    int m_Amount = 1;

    public override string Description => $"{typeof(XPReward)}: {m_Amount}";
}