using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Main = 0,
    Sub,
    Event
}



[CreateAssetMenu(menuName = "Quest/Create Quest", fileName = "Quest_0")]
public class Quest : ScriptableObject
{
    [SerializeField]
    private int uniqueID;

    [SerializeField]
    private int questID;

    [SerializeField]
    private int tribe;

    [SerializeField]
    private QuestType questType;

    [SerializeField]
    private QuestActionType actionType;

    [SerializeField]
    private string title;

    [SerializeField]
    private string desciption;

    [SerializeField]
    private List<RewardItem> rewardItems;

    [SerializeField]
    private List<int> rewardCounts;

    [SerializeField]
    private int zoneNumber;

    [SerializeField]
    private int targetIndex;

    [SerializeField]
    private int countToClear;

    public int UniqueID { get => uniqueID; set => uniqueID = value; }
    public int QuestID { get => questID; set => questID = value; }
    public int Tribe { get => tribe; set => tribe = value; }
    public QuestType QuestType { get => questType; set => questType = value; }
    public QuestActionType ActionType { get => actionType; set => actionType = value; }
    public string Title { get => title; set => title = value; }
    public string Desciption { get => desciption; set => desciption = value; }
    public List<RewardItem> RewardItems { get => rewardItems; set => rewardItems = value; }
    public List<int> RewardCounts { get => rewardCounts; set => rewardCounts = value; }
    public int ZoneNumber { get => zoneNumber; set => zoneNumber = value; }
    public int TargetIndex { get => targetIndex; set => targetIndex = value; }

    public int CountToClear { get => countToClear; set => countToClear = value; }

}


