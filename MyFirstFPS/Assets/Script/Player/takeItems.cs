using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItems : MonoBehaviour
{
    private Transform takebleObject;
    [SerializeField]
    private float takeDistance = 3f;
    [SerializeField]
    private float throwForce = 10;
    [SerializeField]
    private Weapon weaponRifle;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (takebleObject != null)
            {
                takebleObject.parent = null;
                takebleObject.gameObject.AddComponent<Rigidbody>();
                takebleObject = null;
            }
            else
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(transform.position, transform.forward, out raycastHit, takeDistance))
                {
                    if (raycastHit.transform.tag.Contains("take"))
                    {
                        takebleObject = raycastHit.transform;
                        takebleObject.parent = transform;
                        Destroy(takebleObject.gameObject.GetComponent<Rigidbody>());
                    }
                    else if (raycastHit.transform.tag.Contains("ammo"))
                    {
                        var ammoBox = raycastHit.transform.gameObject.GetComponent<AmmoBox>();
                        int lackBullets = weaponRifle.maxBulletsCount - weaponRifle.currentBulletsCount;

                        if (lackBullets <= 0) 
                        {
                            Debug.Log("Магазин заполнен");
                            return;
                        }

                        if (weaponRifle.CheckAmmoType(ammoBox.boxAmmoType))
                        {
                            int bulletsToRefill = ammoBox.TakeBullets(lackBullets);
                            weaponRifle.RefilAmmo(bulletsToRefill);
                        }
                        else
                        {
                            Debug.Log("Неподходящий тип патронов");
                        }
                        
                    }
                }
            }


        }

        if (Input.GetKeyDown(KeyCode.Q) && takebleObject != null)
        {
            takebleObject.gameObject.AddComponent<Rigidbody>();
            takebleObject.parent = null;
            takebleObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            takebleObject = null;

        }
    }


}
