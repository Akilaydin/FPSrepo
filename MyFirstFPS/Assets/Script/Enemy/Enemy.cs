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
    private void Start()
    {
        emeraldAI = GetComponent<EmeraldAISystem>();
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
}
