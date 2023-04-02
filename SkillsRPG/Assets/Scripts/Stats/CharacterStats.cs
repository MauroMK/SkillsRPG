using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealt = 100;
    public int currentHealth {get; private set;}

    public Stat damage;
    public Stat armor;

    void Awake() 
    {
        currentHealth = maxHealt;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            TakeDamage(10);
    }

    void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);      // Stabilizing so that if the damage is lower than the armor, the player don't get healed

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Die
        // Is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
