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

    public void MakeExplosion()
    {
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
        
    }

    private Collider[] GetExplosionColliders()
    {
        Collider[] explosionColliders;
        explosionColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        return explosionColliders;
    }
}
