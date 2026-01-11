using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAction_ButtonAction : QuestAction
{
    public override void Action(Quest quest)
    {
        // quest의 타겟에 접근하게 유도하는 Marker를 활성화 한다.
        QuestManager.Instance.CheckMarker();
    }
}
