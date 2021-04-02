using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }


    [SerializeField]
    Text bulletsCountText;
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
        bulletsCountText.text = currentBullets + "/" + maxBullets;
    }
}
