using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    ButtonToTarget = 0,
    KillMonster = 1,
    MoveToTarget = 2,
    Take = 3,
}

[CreateAssetMenu(menuName ="Quest/Create QuestActionType", fileName ="QuestActionType_")]
public class QuestActionType : ScriptableObject
{
    [SerializeField]
    private ActionType actionTypeIndex;

    public ActionType ActionTypeIndex => actionTypeIndex;
}
