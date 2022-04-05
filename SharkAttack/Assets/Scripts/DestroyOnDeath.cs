using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthModule))]
public class DestroyOnDeath : MonoBehaviour {
    [SerializeField] HealthModule _health;

    private void Reset() {
        _health = GetComponent<HealthModule>();
    }

    void Awake() {
        if (_health != null) { _health.OnDeath += DestroyGameObject; }
    }

    void OnDestroy() {
        if (_health != null) { _health.OnDeath -= DestroyGameObject; }
    }

    void DestroyGameObject(HealthModule health) {
        Destroy(health.gameObject);
    }
}
