using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EmeraldAI;
using EmeraldAI.Example;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField]
    private TextMesh text3D;
    [SerializeField]
    private EmeraldAIPlayerHealth playerHealth; 

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }


    public void ShowDeathScreen()
    {
        Debug.Log("Lost");
    }

    public void RefreshBulletUI(int currentBullets, int maxBullets)
    {
        text3D.text = currentBullets + "/" + maxBullets;
    }

    public void RefresHealthUI()
    {
        Debug.Log(playerHealth.CurrentHealth + "/" + playerHealth.StartingHealth);
    }
}
