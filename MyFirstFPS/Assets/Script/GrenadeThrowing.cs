using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrowing : MonoBehaviour
{
    [SerializeField]
    private GameObject grenadePrefab;
    [SerializeField]
    private float throwCooldown = 1f;
    [SerializeField]
    private float throwForce;
    [SerializeField]
    private float grenadeDestructionDelay = 3f;
    [SerializeField]
   

    private float nextTimeToThrow = 1f;

    private void Update()
    {
        nextTimeToThrow += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G) && nextTimeToThrow >= throwCooldown)
        {
            nextTimeToThrow = 0;
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        Vector3 playerPosition = transform.position;
        GameObject grenade = Instantiate(grenadePrefab, new Vector3(playerPosition.x,playerPosition.y,playerPosition.z), Quaternion.identity);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        grenade.GetComponent<Rigidbody>().AddTorque(new Vector3(100,100,100), ForceMode.Impulse);
        StartCoroutine(grenade.GetComponent<Grenade>().MakeDelayedExplosion(grenadeDestructionDelay));
        StartCoroutine(DestroyGrenade(grenade));
    }

    private IEnumerator DestroyGrenade(GameObject grenade)
    {
        yield return new WaitForSeconds(grenadeDestructionDelay + 0.5f);
        Destroy(grenade);
        

    }
}
