using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour //In order to store bullets and parameters that individual for every particular weapon.
{
    [SerializeField]
    private AmmoType weaponAmmoType;
    public int maxBulletsCount = 30; 
    [SerializeField]
    private int bulletsPerShot = 1;
    public int currentBulletsCount;
    

    private void Start() {
        currentBulletsCount = maxBulletsCount;
    }
    
    public void DecreaseBulletsCountByShot()
    {
        currentBulletsCount -= bulletsPerShot;
        GameManager.instance.RefreshBulletUI(currentBulletsCount,maxBulletsCount);
    }

    public bool isHavingEnoughBulletsToShot()
    {
        if (currentBulletsCount >= bulletsPerShot)
        {
            return true;
        }
        return false;
    }

    public bool CheckAmmoType(AmmoType ammoType)
    {
        if (weaponAmmoType == ammoType)
        {
            return true;
        }
        return false;
    }
    public void RefilAmmo(int pickUpAmmoAmount)
    {
        currentBulletsCount += pickUpAmmoAmount;
        currentBulletsCount = Mathf.Clamp(currentBulletsCount, 0, maxBulletsCount);
        GameManager.instance.RefreshBulletUI(currentBulletsCount, maxBulletsCount);
    }
}
