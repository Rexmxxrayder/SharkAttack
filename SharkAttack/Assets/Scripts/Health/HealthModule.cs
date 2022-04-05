using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModule : MonoBehaviour, IHealth {
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHealth;

    public System.Action<HealthModule, int> OnHit;
    public System.Action<HealthModule> OnDeath;

    public int Health => currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void LoseLife(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        OnHit?.Invoke(this, amount);

        if (currentHealth == 0) {
            Death();
        }
    }

    public void Death() {
        OnDeath?.Invoke(this);
    }
}
