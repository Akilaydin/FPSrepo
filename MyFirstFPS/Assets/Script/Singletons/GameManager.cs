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
    [HideInInspector]

    private GameObject player;

    private int TotalScore;
    private int TotalMoney;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<EmeraldAIPlayerHealth>();
    }
    public void DeathOfPlayer()
    {
        Debug.Log("Lost");
        ShowDeathScreen();
    }
    private void ShowDeathScreen()
    {

    }

    public void RefreshBulletUI(int currentBullets, int maxBullets)
    {
        text3D.text = currentBullets + "/" + maxBullets;
    }

    public void RefresHealthUI()
    {
        Debug.Log(playerHealth.CurrentHealth + "/" + playerHealth.StartingHealth);
    }

    #region ScoreAccessible
    public int GetTotalScore()
    {
        return TotalScore;
    }
    public void SetTotalScore(int totalScore)
    {
        TotalScore = totalScore;
    }

    public void IncreaseTotalScore(int increaseAmount)
    {
        TotalScore += increaseAmount;
    }

    public void DecreaseTotalScore(int decreaseAmount)
    {
        TotalScore -= decreaseAmount;
    }
    #endregion


    #region MoneyAccessible
    public int GetTotalMoney()
    {
        return TotalMoney;
    }

    public void IncreaseTotalMoney(int increaseAmount)
    {
        TotalMoney += increaseAmount;
    }

    public void DecreaseTotalMoney(int decreaseAmount)
    {
        TotalMoney -= decreaseAmount;
    }

    public void SetTotalMoney(int totalMoney)
    {
        TotalMoney = totalMoney;
    }
    #endregion
}
