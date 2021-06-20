using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public delegate void QuestGoalChangedAction();
    public event QuestGoalChangedAction onQuestGoalChanged;
    public void QuestGoalChanged()
    {
        onQuestGoalChanged?.Invoke();
    }

    public delegate void QuestCompletedAction(Quest quest);
    public event QuestCompletedAction onQuestCompleted;
    public void QuestCompleted(Quest quest)
    {
        onQuestCompleted?.Invoke(quest);
    }
}
