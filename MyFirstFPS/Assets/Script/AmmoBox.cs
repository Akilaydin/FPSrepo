using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public AmmoType boxAmmoType;
    [SerializeField]
    private int boxInitialBulletsCount;
    private int boxCurrentBulletsCount;

    private void Start()
    {
        boxCurrentBulletsCount = boxInitialBulletsCount;
    }

    public int TakeBullets(int takeAmount)
    {
        Debug.Log(boxCurrentBulletsCount);
        if ((boxCurrentBulletsCount - takeAmount) >= 0) //Если в ящике хватает патронов для пополнения на запрашиваемое количество
        {
            boxCurrentBulletsCount -= takeAmount;
            
            return takeAmount;
        }
        else
        {
            DestroyAmmoBox();
            Debug.Log("d");
            return boxCurrentBulletsCount;
        }
    }

    private void DestroyAmmoBox()
    {
        Destroy(this.gameObject);
    }
}
