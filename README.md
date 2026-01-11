[퀘스트 에디터 시스템 설명]
- scriptableObject을 이용하여 퀘스트 정보 및 보상 정보를 에디터에서 작업 할 수 있도록 시스템을 구현했습니다.
- 퀘스트 타입은 QuestActionType에 따라 처치/이동/전달 등의 액션 등으로 구별 할 수 있게 설정했습니다.
- JSON 저장 기능을 추가하여 기획자가 데이터를 저장하여 활용 할 수 있도록 설정했습니다.

[에디터에서 퀘스트를 생성하는 순서]
1. Tool/Open QuestSystem으로 퀘스트 시스템 윈도우를 엽니다.
2. 퀘스트 목록이 나오며, 퀘스트가 없다면 Create Quest버튼을 눌러 빈 퀘스트를 생성합니다.
3. Tribe값, QuestID값을 입력합니다.
4. QuestActionType을 선택합니다.
5. Title, Description을 입력합니다.
6. RewardItem을 적용합니다.
<img width="655" height="436" alt="QuestSystem" src="https://github.com/user-attachments/assets/aa95602d-1ad4-4c02-a781-12c07a7da417" />




[퀘스트 진행 순서]
1. 서버로 부터 캐릭터가 할 수 있는 퀘스트들의 상태 정보를 요청하여 받아옵니다.(테스트 씬에서는 서버에서 데이터를 받아왔다고 가정하고, QuestManager가 바로 적용합니다.)
2. 가져온 Quest 정보로 UI를 표시합니다. (제목, 상세정보, 퀘스트 이미지 등..)
3. 퀘스트 UI 터치 입력 시, 퀘스트 진행 상태 값과 Quest 정보의 QuestActionType 정보를 확인하여 Action을 적용합니다. (Action 타입에 따라 서버에 패킷을 요청하기도 하고 클라이언트에서 기능을 실행하기도 합니다.)
   - Action은 퀘스트 진행 중 해야 할 액션을 정의합니다. (어떤 버튼을 눌러야 하는지 마크 해주는 액션, 몬스터를 잡기 위해 이동하는 액션 등...)
4. 퀘스트를 진행하고 서버로부터 완료 값이 오면 Quest 정보로 퀘스트 완료 보상을 적용합니다.
