using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EmeraldAI;

public class Enemy : MonoBehaviour
{
    public int EnemyID;
    public string EnemyName;


    private EmeraldAISystem emeraldAI;
    
    public Enemy(int enemyID, string enemyName)
    {
        EnemyID = enemyID;
        EnemyName = enemyName;
    }
    private void Awake()
    {
        emeraldAI = GetComponent<EmeraldAISystem>();
    }
    private void OnEnable()
    {
        if (emeraldAI.DeathEvent != null)
            emeraldAI.DeathEvent.AddListener(() => { Death(); });
    }
    private void OnDisable()
    {
        if (emeraldAI.DeathEvent != null)
            emeraldAI.DeathEvent.RemoveListener(() => { Death(); });
    }
    public void GetDamage(int damage, EmeraldAISystem.TargetType type,Transform attackerTransform)
    {
        emeraldAI.Damage(damage, type, attackerTransform);
    }

    public void Initialize(int enemyID, string enemyName)
    {
        EnemyID = enemyID;
        EnemyName = enemyName;
    }
    public void Death()
    {
        QuestSystem.instance.FulfillQuests(EnemyID,1);
    }
}
