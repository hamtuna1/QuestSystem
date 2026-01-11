using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private int CompleteQuestID;

    public void OnClickMainMenu()
    {
        QuestManager.Instance.RequestComplete(CompleteQuestID);
    }
}
