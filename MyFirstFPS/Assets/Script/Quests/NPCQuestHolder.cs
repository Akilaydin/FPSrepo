using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestHolder : MonoBehaviour
{
    private Dictionary<int, Quest> holdersCurrentQuests;
    private Dictionary<int, Quest> holdersPendingQuests;

    private void Start()
    {
        holdersCurrentQuests = new Dictionary<int, Quest>();
        holdersPendingQuests = new Dictionary<int, Quest>();
        Quest killQuest = new Quest(1, "Dog hunter", "Kill 10 awful dogs", 1, 100, QuestType.KillQuest, 5);
        holdersCurrentQuests.Add(killQuest.QuestID, killQuest);
    }
    public Dictionary<int, Quest> GetCurrentHoldersQuests()
    {
        return holdersCurrentQuests;
    }
    public Dictionary<int, Quest> GetPendingHoldersQuests()
    {
        return holdersPendingQuests;
    }
    public Quest GetQuestFromCurrent(int questID)
    {
        if (holdersCurrentQuests.ContainsKey(questID))
        {
            RemoveQuestFromHolder(questID);
            AddQuestToPending(holdersCurrentQuests[questID]);
            return holdersCurrentQuests[questID];
        }
        else
        {
            Debug.Log("There is no current quest with the given ID");
            return null;
        }
         
    }
    public Quest GetQuestFromPending(int questID)
    {
        if (holdersPendingQuests.ContainsKey(questID))
        {
            return holdersPendingQuests[questID];
        }
        else
        {
            Debug.Log("There is no pending quest with the given ID");
            return null;
        }
    }


    private void RemoveQuestFromHolder(int questID)
    {
        holdersCurrentQuests.Remove(questID);
    }
    private void AddQuestToPending(Quest quest)
    {
        holdersPendingQuests.Add(quest.QuestID, quest);
    }
}
