using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quest/Create QuestActionType", fileName ="QuestActionType_")]
public class QuestActionType : ScriptableObject
{
    [SerializeField]
    private int actionTypeIndex;

    public int ActionTypeIndex => actionTypeIndex;
}
