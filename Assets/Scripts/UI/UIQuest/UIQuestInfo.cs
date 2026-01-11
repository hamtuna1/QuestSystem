using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public enum QuestState
{
    Ready,
    Playing,
    Complete,
    AllComplete,
}

public class UIQuestInfo : MonoBehaviour
{
    public Text QuestTitle;
    public Text QuestDesc;

    private Quest quest;
    private QuestState questState;

    public void SetQuestAllComplete()
    {
        questState = QuestState.AllComplete;
        UpdateUI();
    }
    public void SetQuestInfo(QuestState state, Quest quest, int param1 = 0)
    {
        questState = state;
        this.quest = quest;
        UpdateUI(param1);
    }
    private void UpdateUI(int param1 = 0)
    {
        StringBuilder description = new StringBuilder();

        switch (questState)
        {
            case QuestState.Ready:
                QuestTitle.text = $"{quest.Title} 시작";
                description.Append(quest.Desciption);
                break;

            case QuestState.Playing:
                QuestTitle.text = $"{quest.Title}";
                description.Append(quest.Desciption);
                break;

            case QuestState.Complete:
                QuestTitle.text = $"{quest.Title} 완료";
                description.Append(quest.Desciption);
                break;

            case QuestState.AllComplete:
                QuestTitle.text = "퀘스트";
                description.Append($"더 이상 진행 할 수 있는 퀘스트가 없습니다.");
                break;
        }

        if (questState != QuestState.AllComplete)
        {
            if (quest.ActionType.ActionTypeIndex == 3)
            {
                description.Append($"\n({param1} / {quest.CountToClear})");
            }
        }

        QuestDesc.text = description.ToString();
    }

    public void OnClickQuestInfo()
    {
        switch (questState)
        {
            case QuestState.Ready:
                CheckQuest();
                break;

            case QuestState.Playing:
                ActionQuest();
                break;

            case QuestState.Complete:
                RequestReward();
                break;
        }
    }

    public void CheckQuest()
    {
        // QuestManager에게 해당 퀘스트를 할 수 있는 법을 요청한다.
        QuestManager.Instance.CheckQuest();
    }

    public void ActionQuest()
    {
        // QuestManager에게 해당 퀘스트 액션을 요청한다.
        QuestManager.Instance.ActionQuest();
    }


    public void RequestReward()
    {
        // QuestManager에게 해당 퀘스트 보상을 요청한다.
        QuestManager.Instance.RequestComplete(quest.QuestID);
    }
}
