using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestRewardPopup : MonoBehaviour
{
    public Text ClearQuestTitle;
    public UIQuestRewardItem[] rewardItems;

    private Quest clearQuest;

    public void SetRewardInfo(Quest quest)
    {
        gameObject.SetActive(true);
        clearQuest = quest;

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (clearQuest == null)
            return;

        ClearQuestTitle.text = $"{clearQuest.Title} Å¬¸®¾î";

        for (int idx = 0; idx < clearQuest.RewardItems.Count; ++idx)
        {
            int count = clearQuest.RewardCounts[idx];
            rewardItems[idx].SetRewardItem(clearQuest.RewardItems[idx], count);
        }
    }


    public void OnClickCloseButton()
    {
        Close();
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }
}
