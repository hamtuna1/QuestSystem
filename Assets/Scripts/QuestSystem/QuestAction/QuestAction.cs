using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestAction : MonoBehaviour
{
    // 퀘스트를 위한 행동 적용
    public abstract void Action(Quest quest);
}
