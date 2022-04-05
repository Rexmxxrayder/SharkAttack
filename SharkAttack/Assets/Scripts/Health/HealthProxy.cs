using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthProxy : MonoBehaviour, IHealth {
    [SerializeField] HealthModule _health;

    public int Health => _health.Health;
    public event UnityAction<IHealth, int> OnHit { add => _health.OnHit += value; remove => _health.OnHit -= value; }
    public event UnityAction<IHealth> OnDeath { add => _health.OnDeath += value; remove => _health.OnDeath -= value; }

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
