using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeItems : MonoBehaviour
{
    private Transform takebleObject;
    [SerializeField]
    private float takeDistance = 3f;
    [SerializeField]
    private float throwForce = 10;
    [SerializeField]
    private Weapon weapon;




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
                        weapon.RefilAmmo();
                        Destroy(raycastHit.transform.gameObject);
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
