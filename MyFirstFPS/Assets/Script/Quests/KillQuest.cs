using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{
    public KillQuest(string nameOfQuest, string textGoal, int rewardAmount, QuestType typeOfQuest) : base(nameOfQuest, textGoal, rewardAmount, typeOfQuest)
    {

    }

    public override void CompleteQuest()
    {
        throw new System.NotImplementedException();
    }

    public override void StartQuest()
    {
        throw new System.NotImplementedException();
    }
}
