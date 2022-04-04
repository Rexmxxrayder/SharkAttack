using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth {
    [SerializeField] HealthModule _health;

    public int Health => _health.Health;
    
    private void Reset() {
        _health = GetComponentInParent<HealthModule>();
    }

    public void LoseLife(int amount) {
        _health.LoseLife(amount);
    }

    public void Death() {
        _health.Death();
    }
}
