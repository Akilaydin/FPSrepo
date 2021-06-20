using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestHolder : MonoBehaviour, IInteractible
{
    public bool HasQuests { get; private set; }
    private Dictionary<int, Quest> holdersCurrentQuests;
    private Dictionary<int, Quest> holdersPendingQuests;

    private void Start()
    {
        holdersCurrentQuests = new Dictionary<int, Quest>();
        holdersPendingQuests = new Dictionary<int, Quest>();
        Quest killQuest = new Quest(1, "Dog hunter", "Kill 10 awful dogs", 1, 100, QuestType.KillQuest, 5);
        AddQuestToCurrent(killQuest);


        if (holdersCurrentQuests.Count > 0)
        {
            HasQuests = true;
        }
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
    private void AddQuestToCurrent(Quest quest)
    {
        holdersCurrentQuests.Add(quest.QuestID, quest);
    }
    public void Interact()
    {
        Debug.Log("Interacting");
    }
}
