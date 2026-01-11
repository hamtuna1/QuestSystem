using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RewardType
{
    GOLD = 0,
    EXP,
    ITEM_ETC,
}

[CreateAssetMenu(menuName = "Quest/Create RewardItem", fileName = "Reward_")]
public class RewardItem : ScriptableObject
{
    [SerializeField]
    private RewardType type;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private string rewardName;

    public RewardType Type => type;

    public string RewardName => rewardName;

    public Sprite Icon => icon;
}
