using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class EntityAttack : MonoBehaviour {
    [SerializeField] float _attackCooldown = 5f;
    [SerializeField] int _damage = 1;

    Coroutine routine_Attack;

    public System.Action<IHealth> OnCollision;
    public System.Action<IHealth> OnAttack;

    void OnCollisionEnter(Collision collision) {
        IHealth health = collision.gameObject.GetComponent<IHealth>();
        if (health != null) {
            Attack(health);
            OnCollision?.Invoke(health);
        }
    }

    public void Attack(IHealth target) {
        Attack(target, _attackCooldown, _damage);
    }

    void Attack(IHealth target, float time, int damage) {
        if (routine_Attack != null) { StopCoroutine(routine_Attack); }
        routine_Attack = StartCoroutine(Attack(target, time, damage));

        IEnumerator Attack(IHealth target, float time, int damage) {
            yield return new WaitForSeconds(time);
            target.LoseLife(damage);
            OnAttack?.Invoke(target);
        }
    }
}
