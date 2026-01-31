using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    public int CurrentHealth => currentHealth;


    public event Action<int> OnHealthChanged;
    public event Action OnDeath;

    private void Start()
    {
       
        currentHealth = maxHealth;
       
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

    
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log($"Can Değişti: {currentHealth}");

        OnHealthChanged?.Invoke(currentHealth);

  
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Öldü!");
        OnDeath?.Invoke();
        
     
    }
}