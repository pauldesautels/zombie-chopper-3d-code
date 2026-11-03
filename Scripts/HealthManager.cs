using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth = 14000;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        SetCurrentHealth(currentHealth -= damage);
        healthBar.SetHealth(GetCurrentHealth());
    }

    public void SetCurrentHealth(int newHealthAmount)
    {
        currentHealth = newHealthAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
