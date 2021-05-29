using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace EmeraldAI.Example
{
    /// <summary>
    /// An example health script that the EmeraldAIPlayerDamage script calls.
    /// Various events can be created and used to cause damage to a 3rd party character controllers via the inspector.
    /// You can also edit the EmeraldAIPlayerDamage script directly and add custom functions.
    /// </summary>
    public class EmeraldAIPlayerHealth : MonoBehaviour
    {
        public int CurrentHealth = 100; [Space]
        [Header("HP REGENERATION")]
        [SerializeField]
        private float hpRegenerationRate;
        [SerializeField]
        private int hpRegenerationAmount;
        [Header("EVENTS")]
        public UnityEvent DamageEvent;
        public UnityEvent DeathEvent;

        [HideInInspector]
        public int StartingHealth;


        private void Start()
        {
            
            StartingHealth = CurrentHealth;
            StartCoroutine(HpRegeneration());
        }

        public void DamagePlayer (int DamageAmount)
        {
            CurrentHealth -= DamageAmount;
            DamageEvent.Invoke();

            if (CurrentHealth <= 0)
            {
                PlayerDeath();
            }
        }

        public void PlayerDeath()
        {
            DeathEvent.Invoke();
        }

        private IEnumerator HpRegeneration()
        {
            while (true)
            {
                if (CurrentHealth < StartingHealth / 2)
                {
                    CurrentHealth += hpRegenerationAmount;
                    yield return new WaitForSeconds(hpRegenerationRate);
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}
