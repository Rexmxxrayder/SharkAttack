using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class BasicBrain : MonoBehaviour {
    [SerializeField] EntityAttack _attack;
    [SerializeField] LinearMovement _movement;
    [SerializeField] HealthModule _health;

    void Awake() {
        _attack.OnCollision += StopMoving;
        _attack.OnAttack += Attack;
        _health.OnDeath += Death;
    }

    private void OnDestroy() {
        _attack.OnCollision -= StopMoving;
        _attack.OnAttack -= Attack;
        _health.OnDeath -= Death;
    }

    void StopMoving(IHealth target) {
        _movement.Moving = false;
    }

    void Attack(IHealth target) {
        _attack.Attack(target);
    }

    void Death(IHealth target) {
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction) {
        _movement.ChangeDirection(direction);
    }
}
