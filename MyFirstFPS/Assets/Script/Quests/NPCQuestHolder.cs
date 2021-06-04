using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestHolder : MonoBehaviour
{
    public Dictionary<int,Quest> holdersQuests;
    public GameObject questTarget;

    private void Start()
    {
        holdersQuests = new Dictionary<int, Quest>();
        Quest killQuest = new Quest(1, "Dog hunter", "Kill 10 awful dogs", 1, 100, QuestType.KillQuest, 5);
        holdersQuests.Add(killQuest.QuestID, killQuest);
    }
}
