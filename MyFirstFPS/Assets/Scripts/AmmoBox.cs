using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    //[SerializeField]
    //private GameObject RifleModel;
    //[SerializeField]
    //private GameObject pistolModel;
    public AmmoType boxAmmoType;
    [SerializeField]
    private int boxInitialBulletsCount;
    private int boxCurrentBulletsCount;
    private TextMesh bulletsText;

    private void Start()
    {
        boxCurrentBulletsCount = boxInitialBulletsCount;
        bulletsText = GetComponentInChildren<TextMesh>();
        
        RefreshBullets();
        
    }

    public int TakeBullets(int takeAmount)
    {
        if ((boxCurrentBulletsCount - takeAmount) >= 0) //Если в ящике хватает патронов для пополнения на запрашиваемое количество
        {
            boxCurrentBulletsCount -= takeAmount;
            RefreshBullets();
            
            return takeAmount;
        }
        else
        {
            DestroyAmmoBox();
            return boxCurrentBulletsCount;
        }
    }
    private void RefreshBullets()
    {
        if (bulletsText != null)
        bulletsText.text = boxCurrentBulletsCount + "/" + boxInitialBulletsCount;
    }

    private void DestroyAmmoBox()
    {
        Destroy(this.gameObject);
    }
}
