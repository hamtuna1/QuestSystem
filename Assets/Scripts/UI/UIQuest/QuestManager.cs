using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance = null;

    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new QuestManager();
            }

            return instance;
        }
    }


    public List<Quest> Quests;
    public List<QuestAction> QuestActions;
    public UIQuest UIQuest;

    // 버튼 퀘스트를 도와주는 Marker 이벤트
    public Action<int> MarkerAction;
    public Action MarkerCleanAction;

    [HideInInspector]
    public int MonsterKillCount = 0;

    private int CurrentQuestID = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIQuest.Init();
        SetQuest();
    }

    public void SetQuest()
    {
        // 할 수 있는 퀘스트가 있는지 확인
        if (QuestIsAllClear() == true)
        {
            UIQuest.SetAllQuestClear();
        }
        else
        {
            CheckQuest();
        }
    }

    public void CheckQuest()
    {
        int param1 = 0;
        QuestState state = QuestState.Ready;

        // 퀘스트의 액션 정보 값을 통해 등록된 Quest 상태를 체크한다.
        if (QuestIsAllClear() == true)
        {
            state = QuestState.AllComplete;
        }
        else
        {
            switch (GetCurrentQuest().ActionType.ActionTypeIndex)
            {
                case 3:
                    param1 = MonsterKillCount;
                    if (MonsterKillCount >= GetCurrentQuest().CountToClear)
                    {
                        RequestComplete(CurrentQuestID);
                        return;
                    }
                    break;
            }
            state = QuestState.Playing;
            
        }
        UIQuest.SetQuestInfo(state, GetCurrentQuest(), param1);
    }

    public Quest GetCurrentQuest()
    {
        for( int idx = 0; idx < Quests.Count; ++idx)
        {
            if (Quests[idx].QuestID == CurrentQuestID)
                return Quests[idx];
        }

        return null;
    }

    public void ActionQuest()
    {
        // 퀘스트를 진행하는 액션을 실행한다.
        Quest quest = GetCurrentQuest();
        int action = quest.ActionType.ActionTypeIndex;
        QuestActions[action].Action(quest);
    }

    public void RequestComplete(int idx)
    {
        if (CurrentQuestID != idx)
            return;


        // 서버로 부터 퀘스트완료를 요청한다.
        // 서버가 없기 때문에 임시로 서버요청 대신에 바로 퀘스트 완료로 적용한다.
        OnQuestCompleted();
    }

    public void OnQuestCompleted()
    {
        if (QuestIsAllClear() == true)
            return;

        UIQuest.SetRewardPopup(GetCurrentQuest());

        MarkerCleanAction?.Invoke();

        if (QuestIsAllClear() == false)
            CurrentQuestID++;

        

        SetQuest();
    }

    public bool QuestIsAllClear()
    {
        for (int idx = 0; idx < Quests.Count; ++idx)
        {
            if (Quests[idx].QuestID >= CurrentQuestID)
                return false;
        }
        return true;
    }

    public void CheckMarker()
    {
        MarkerAction?.Invoke(CurrentQuestID);
    }
}
