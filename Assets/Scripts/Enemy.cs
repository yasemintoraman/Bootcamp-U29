using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private int currentHealth, maxHealth;

    private bool canTakeDamage = true;
    public bool IsPlayerDead = false;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;

            //maybe play hurt animation

            animator.SetTrigger("Hit1");

            if (currentHealth == 0)
            {
                Die();
                IsPlayerDead = true;
            }

            StartCoroutine(StartDamageCooldown());
        }
    }

    private IEnumerator StartDamageCooldown()
    {
        canTakeDamage = false;

        // Wait for a certain duration before the enemy can take damage again
        yield return new WaitForSeconds(1f); // Change the duration as needed

        canTakeDamage = true;
    }

    void Die()
    {

        Debug.Log("Enemy died!");
        //die animation
        //animator.SetBool("IsDead", true);
        animator.SetTrigger("Fall1");

    }

}