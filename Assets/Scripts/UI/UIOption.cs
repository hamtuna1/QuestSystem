using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOption : MonoBehaviour
{
    [SerializeField]
    private int CompleteQuestID;
    public void OnClickOptionButton()
    {
        QuestManager.Instance.RequestComplete(CompleteQuestID);
    }
}
