using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    public delegate void HealthChangeEvent(int currentHealth);
    public event HealthChangeEvent OnHealthChange;

    public delegate void Death();
    public event Death OnDeath;

    private void Start()
    {
        health = maxHealth;
        OnHealthChange += currentHealth =>
        {
            if (currentHealth <= 0)
            {
                OnDeath();
                Destroy(gameObject);
            }
        };
    }

    public void ModifyHealth(int amount)
    {
        health += amount;
        OnHealthChange(health);
    }

    private void OnValidate()
    {
        if (maxHealth <= 0)
        {
            maxHealth = 1;
        }
    }
}
