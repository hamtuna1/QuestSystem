using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestMarker : MonoBehaviour
{
    [SerializeField]
    private int questID;

    public Image Mark;

    private void OnEnable()
    {
        QuestManager.Instance.MarkerAction += SetMarker;
        QuestManager.Instance.MarkerCleanAction += Reset;
    }

    private void OnDisable()
    {
        QuestManager.Instance.MarkerAction -= SetMarker;
        QuestManager.Instance.MarkerCleanAction -= Reset;
    }

    public void Reset()
    {
        Mark.gameObject.SetActive(false);
    }

    public void SetMarker(int questID)
    {
        bool isActive = this.questID == questID;
        Mark.gameObject.SetActive(isActive);
    }
}
