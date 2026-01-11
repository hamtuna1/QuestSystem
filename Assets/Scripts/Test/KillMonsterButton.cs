using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonsterButton : MonoBehaviour
{
    [SerializeField]
    private int QuestID;
    public void OnClickKillMonsterButton()
    {
        Quest quest = QuestManager.Instance.GetCurrentQuest();
        if(quest == null)
            return;
        
        if (quest.QuestID == QuestID)
            QuestManager.Instance.MonsterKillCount++;

        if (QuestManager.Instance.QuestIsAllClear() == false)
            QuestManager.Instance.CheckQuest();
    }
}
