using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI;
using EmeraldAI.Example;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private int explosionDamage;
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private GameObject bigExplosion;

    public void MakeExplosion()
    {
        GameObject explosion = Instantiate(bigExplosion, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        foreach (var collider in GetExplosionColliders())
        {
            if (collider.GetComponent<EmeraldAISystem>())
            {
                collider.GetComponent<EmeraldAISystem>().Damage(explosionDamage, EmeraldAISystem.TargetType.Player,transform);
            }

            if (collider.GetComponent<EmeraldAIPlayerHealth>())
            {
                collider.GetComponent<EmeraldAIPlayerHealth>().DamagePlayer(explosionDamage);
            }

        }
        Destroy(gameObject);
        
    }

    private Collider[] GetExplosionColliders()
    {
        Collider[] explosionColliders;
        explosionColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        return explosionColliders;
    }

    public IEnumerator MakeDelayedExplosion(float delay)
    {
        yield return new WaitForSeconds(delay);
        MakeExplosion();

    }
}
