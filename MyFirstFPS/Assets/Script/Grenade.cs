using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private int explosionDamage;
    [SerializeField]
    private float explosionRadius;

    public void MakeExplosion()
    {
        foreach (var collider in GetExplosionColliders())
        {
            if (collider.GetComponent<Enemy>())
            {
                collider.GetComponent<Enemy>().GetDamage(explosionDamage);
            }

            if (collider.GetComponent<Player>())
            {
                collider.GetComponent<Player>().GetDamage(explosionDamage);
            }
        }
        
    }

    private Collider[] GetExplosionColliders()
    {
        Collider[] explosionColliders;
        explosionColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        return explosionColliders;
    }
}
