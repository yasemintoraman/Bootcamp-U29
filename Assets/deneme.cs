using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public int maxHealth = 60;
    int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //maybe play hurt animation


        if (currentHealth <= 0)
        {
            Die();
        }


    }

    void Die()
    {

        Debug.Log("Player died!");
        //die animation
        //animator.SetBool("IsDead", true);

        //disable the enemy
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
