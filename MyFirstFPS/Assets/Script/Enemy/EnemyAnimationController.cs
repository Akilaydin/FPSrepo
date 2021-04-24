using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;

    private string isWalking = "isWalkingBool";
    private string isRunning = "isRunningBool";
    private string isAttacking1 = "isAttacking1";
    private string isAttacking2 = "isAttacking2";
    private string isDead = "isDead";
    private string isIdling = "isIdleBool";

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    public void SetIdleAnimation()
    {
        animator.SetBool(isIdling, true);
    }

    public void SetAttackAnimation()
    {
       if (animator.GetBool(isAttacking2) == false) //Если только одна анимация атаки
       {
            animator.SetBool(isAttacking1,true);
       }
       else
       {
            if (Random.Range(1,2) == 1)
            {
                animator.SetBool(isAttacking1, true);
            } 
            else
            {
                animator.SetBool(isAttacking2, true);
            }
       }
    }
    
    public void SetWalkAnimation()
    {
        animator.SetBool(isWalking, true);
    }

    public void SetRunAnimation()
    {
        animator.SetBool(isRunning, true);
    }

    public void SetDeathAnimation()
    {
        animator.SetTrigger(isDead);
    }
}
