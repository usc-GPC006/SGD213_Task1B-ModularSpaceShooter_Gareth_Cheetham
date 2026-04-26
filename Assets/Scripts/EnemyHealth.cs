using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public int CurrentHealth { get { return currentHealth; } }
    int currentHealth;
    // get the maximum health of this health component
    public int MaxHealth { get { return maxHealth; } }
    [SerializeField]
    int maxHealth;


    void Start()
    {
        //Set current health to be equal to the ship's maximum
        currentHealth = maxHealth;
    }
    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Heal handles the functionality of receiving health
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain, this value should be positive</param>
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary cleanup.
    /// </summary>
    public void Die()
    {
        Destroy(gameObject);
    }
}
