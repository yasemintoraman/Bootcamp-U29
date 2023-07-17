using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private int currentHealth, maxHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //maybe play hurt animation

        animator.SetTrigger("Hit1");

        if (currentHealth == 0)
        {
            Die();
        }

    }

    void Die()
    {

        Debug.Log("Enemy died!");
        //die animation
        //animator.SetBool("IsDead", true);
        animator.SetTrigger("Fall1");

    }

}