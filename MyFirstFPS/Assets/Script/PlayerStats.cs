using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int playerMaxHP = 5;
    private int playerHP;
    
    void Start()
    {
        playerHP = playerMaxHP;
    }

    public void GetDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        GameManager.instance.ShowDeathScreen();
    }
}
