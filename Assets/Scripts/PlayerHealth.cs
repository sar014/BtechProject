using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deletePlayer;
    public Image HealthBar;
    bool isDead;
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    void Update()
    {
        HealthBar.fillAmount = (float)currentHealth/maxHealth;
    }

    // Method to reduce player's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if health is zero or less
        if (currentHealth <= 0)
        {
            isDead = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyBehavior enemyBehavior = other.gameObject.GetComponent<EnemyBehavior>();
            enemyBehavior.animator.SetTrigger("Attack");
            TakeDamage(5);
        }
        else if (other.gameObject.CompareTag("Mutant"))
        {
            TakeDamage(7);
        }
    }

}
