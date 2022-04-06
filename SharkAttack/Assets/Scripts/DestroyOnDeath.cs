using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthModule))]
public class DestroyOnDeath : MonoBehaviour {
    [SerializeField] HealthModule _health;
    [SerializeField] GameObject _parent;

    private void Reset() {
        _health = GetComponent<HealthModule>();
        _parent = gameObject;
    }

    void Awake() {
        if (_health != null) { _health.OnDeath += DestroyGameObject; }
    }

    void OnDestroy() {
        if (_health != null) { _health.OnDeath -= DestroyGameObject; }
    }

    void DestroyGameObject(IHealth health) {
        Destroy(_parent);
    }
}
