using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
[RequireComponent(typeof(EnemyAnimationController))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyMaxHp = 100;
    private int enemyCurrentHP;
    private EnemyAI enemyAI;
    private EnemyAnimationController enemyAnimController;
    
    void Start()
    {
        enemyCurrentHP = enemyMaxHp;
        enemyAI = gameObject.GetComponent<EnemyAI>();
        enemyAnimController = gameObject.GetComponent<EnemyAnimationController>();
    }

    public void GetDamage(int damage)
    {
        Debug.Log("EnemyHP = " + enemyCurrentHP);
        if ((enemyCurrentHP - damage) <= 0)
        {
            EnemyDestruction();
            return;
        }
        else
        {
            enemyCurrentHP -= damage;
        }

    }

    private void EnemyDestruction()
    {
        
        enemyAnimController.SetDeathAnimation();
        this.gameObject.GetComponent<Enemy>().enabled = false;
        this.gameObject.GetComponent<EnemyAI>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject,5f);
    }
}
