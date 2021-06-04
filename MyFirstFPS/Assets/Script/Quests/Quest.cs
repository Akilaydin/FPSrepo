using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Quest
{

    public int QuestID;
    public int GoalID;
    public string NameOfQuest;
    public string TextGoal;
    public int RewardAmount;
    public QuestType TypeOfQuest;
    public int RequiredAmount;
    public bool isCompleted;

    public int currentAmount { get; private set; }

    public Quest(int questID, string nameOfQuest, string textGoal, int goalID, int rewardAmount, QuestType typeOfQuest, int requiredAmount)
    {
        QuestID = questID;
        NameOfQuest = nameOfQuest;
        TextGoal = textGoal;
        GoalID = goalID;
        RewardAmount = rewardAmount;
        TypeOfQuest = typeOfQuest;
        RequiredAmount = requiredAmount;
    }

    public void StartQuest()
    {
        Debug.Log("The quest " + NameOfQuest + " has been started!");
    }
    public void CompleteQuest()
    {
        Debug.Log("The quest " + NameOfQuest + " has been ended!");
    }
    public int GetReward()
    {
        return RewardAmount;
    }
    public void FailQuest()
    {
        Debug.Log("The quest " + NameOfQuest + " has been failed!");
    }

    public void IncreaseQuestAmount(int amount)
    {
        if (isCompleted == false)
        {
            currentAmount += amount;
            GameEvents.instance.QuestGoalChanged();
            if (currentAmount >= RequiredAmount)
            {
                isCompleted = true;
                GameEvents.instance.QuestCompleted(this);
            }
        }
    }
    public int GetCurrentAmount()
    {
        return currentAmount;
    }

    public bool CheckTargetID(int targetID)
    {
        return targetID == GoalID;
    }
}
