using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ToolsBoxEngine;

public class HealthModule : MonoBehaviour, IHealth {
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHealth;

    [SerializeField] UnityEvent<IHealth, int> _onHit;
    [SerializeField] UnityEvent<IHealth> _onDeath;

    public event UnityAction<IHealth, int> OnHit { add => _onHit.AddListener(value); remove => _onHit.RemoveListener(value); }
    public event UnityAction<IHealth> OnDeath { add { _onDeath.AddListener(value); } remove => _onDeath.RemoveListener(value); }

    public int Health => currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void LoseLife(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        _onHit?.Invoke(this, amount);

        if (currentHealth == 0) {
            Death();
        }
    }

    public void Death() {
        _onDeath?.Invoke(this);
    }

    public int GetCurrentHealth(int amount) {
        return currentHealth;
    }
}
