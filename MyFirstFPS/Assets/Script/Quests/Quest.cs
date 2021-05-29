using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest
{
    public string NameOfQuest { get; private set; }
    public string TextGoal { get; private set; }
    public int RewardAmount { get; private set; }
    public QuestType TypeOfQuest  { get; private set; }

    public Quest(string nameOfQuest, string textGoal, int rewardAmount, QuestType typeOfQuest)
    {
        NameOfQuest = nameOfQuest;
        TextGoal = textGoal;
        RewardAmount = rewardAmount;
        TypeOfQuest = typeOfQuest;
    }

    public abstract void StartQuest();
    public abstract void CompleteQuest();
    public int GetReward()
    {
        return RewardAmount;
    }
    public virtual void FailQuest()
    {
        Debug.Log("QuestHasBeenFailed");
    }
}
