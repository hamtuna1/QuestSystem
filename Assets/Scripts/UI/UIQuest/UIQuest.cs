using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuest : MonoBehaviour
{
    public UIQuestInfo QuestInfo;
    public UIQuestRewardPopup QuestRewardPopup;
    public UIQuestMarker[] QuestMarkers;

    public void Init()
    {
        for (int idx = 0; idx < QuestMarkers.Length; ++idx)
        {
            QuestMarkers[idx].gameObject.SetActive(true);
        }
    }

    public void SetAllQuestClear()
    {
        QuestInfo.SetQuestAllComplete();

    }

    public void SetQuestInfo(QuestState state, Quest quest, int param1 = 0)
    {
        QuestInfo.SetQuestInfo(state, quest, param1);
    }

    public void SetRewardPopup(Quest quest)
    {
        QuestRewardPopup.SetRewardInfo(quest);
    }
}
