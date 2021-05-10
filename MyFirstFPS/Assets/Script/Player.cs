using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerMaxHP = 5;
    private int playerCurrentHP;
    
    void Start()
    {
        playerCurrentHP = playerMaxHP;
    }

    public void GetDamage(int damage)
    {
        Debug.Log("PlayerHp = " + playerCurrentHP);
        if ((playerCurrentHP - damage) <= 0)
        {
            PlayerDeath();
            return;
        }
        else
        {
            playerCurrentHP -= damage;
        }
    }

    public void PlayerDeath()
    {
        GameManager.instance.ShowDeathScreen();
    }
}
