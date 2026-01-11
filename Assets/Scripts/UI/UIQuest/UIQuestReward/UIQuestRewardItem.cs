using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestRewardItem : MonoBehaviour
{
    public Image RewardItemIcon;
    public Text RewardCountText;
    public void SetRewardItem(RewardItem item, int count)
    {
        RewardItemIcon.sprite = item.Icon;
        RewardCountText.text = $"{item.RewardName} x{count}";
    }
}
