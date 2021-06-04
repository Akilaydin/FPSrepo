using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{


    public static QuestSystem instance;

    public Dictionary<int,Quest> takenQuests;
    public Dictionary<int, Quest> completedQuests;
    [HideInInspector]
    public Quest currentQuest;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        takenQuests = new Dictionary<int, Quest>();
        completedQuests = new Dictionary<int, Quest>();
        Quest killQuest = new Quest(1, "Dog hunter", "Kill 10 awful dogs", 1, 100, QuestType.KillQuest, 10);
        takenQuests.Add(killQuest.QuestID, killQuest);
        currentQuest = killQuest;
    }

    private void OnEnable()
    {
        GameEvents.instance.onQuestGoalChanged += OnCurrentQuestGoalChanged;
        GameEvents.instance.onQuestCompleted += OnQuestCompleted;
    }

    private void OnDisable()
    {
        GameEvents.instance.onQuestGoalChanged -= OnCurrentQuestGoalChanged;
        GameEvents.instance.onQuestCompleted -= OnQuestCompleted;
    }

    #region QuestsEvents
    private void OnCurrentQuestGoalChanged()
    {
        Debug.Log(currentQuest.GetCurrentAmount());
        int a = currentQuest.RequiredAmount - currentQuest.currentAmount;
        Debug.Log(currentQuest.NameOfQuest + " is compliting. Now you have to kill/gather only " + a);
    }
    private void OnCurrentQuestChanged()
    {
        Debug.Log("Now current quest is " + currentQuest.NameOfQuest);
    }
    private void OnQuestCompleted(Quest quest)
    {
        Debug.Log(quest.NameOfQuest + " has been completed!");
        completedQuests.Add(quest.QuestID, quest);
        takenQuests.Remove(quest.QuestID);
        SetRandomCurrentQuest();
    }
    #endregion



    public void AddQuestToTaken(Quest quest)
    {
        takenQuests.Add(quest.QuestID,quest);
    }
    public void RemoveQuestFromTaken(int questID)
    {
        if (takenQuests.ContainsKey(questID)) //If the quest that we want to remove exists...
        {
            takenQuests.Remove(questID);
            SetRandomCurrentQuest();
        }
    }
    public void FulfillQuests(int targetID, int amount) 
    {
        
        foreach (var quest in takenQuests)
        {
            if (quest.Value.CheckTargetID(targetID))
            {
                quest.Value.IncreaseQuestAmount(amount);
            }
        }
    }
    private void SetCurrentQuest(Quest quest)
    {
        currentQuest = quest;
    }
    private Quest FindQuestInTakenByID(int questID)
    {
        return takenQuests[questID];
    }
    private void SetRandomCurrentQuest()
    {
        if (IsHavingAnyTakenQuests() == true)
        {
            currentQuest = takenQuests[Random.Range(0, takenQuests.Count)];
            OnCurrentQuestChanged();
        }
    }

    private bool IsHavingAnyTakenQuests()
    {
        if (takenQuests.Count <= 0)
        {
            Debug.Log("You have no quests " + takenQuests.Count);
            return false;
        }
        return true;
    }
}
