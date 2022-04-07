using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ToolsBoxEngine;
using MoreMountains.Feedbacks;

public class BasicBrain : MonoBehaviour {
    [SerializeField] Animator _animator;
    [SerializeField] EntityAttack _attack;
    [SerializeField] LinearMovement _movement;
    [SerializeField] HealthModule _health;
    [SerializeField] int _side;
    [SerializeField] UnityEvent<BasicBrain> _onDeath;
    [SerializeField] UnityEvent _onAttack;
    [SerializeField] UnityEvent _onMove;

    IHealth _attackingTarget = null;

    public int Side { get => _side; set => SetSide(value); }
    public HealthModule Health => _health;

    public event UnityAction<BasicBrain> OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }
    public float AttackCooldown { get => _attack.Cooldown; set => _attack.Cooldown = value; }

    void Awake() {
        _attack.OnCollision += StopMoving;
        _attack.OnAttack += Attack;
        _health.OnDeath += Death;
    }

    private void OnDestroy() {
        _attack.OnCollision -= StopMoving;
        _attack.OnAttack -= Attack;
        _health.OnDeath -= Death;
        if (_attackingTarget != null) { _attackingTarget.OnDeath -= OnDestroyRaft; }
    }

    void StopMoving(IHealth target) {
        _movement.Moving = false;
        _attackingTarget = target;
        target.OnDeath += OnDestroyRaft;
        if (_animator != null) { _animator.SetBool("Moving", false); }
    }

    void Attack(IHealth target) {
        _attack.Attack(target);
    }

    void Death(IHealth target) {
        _onDeath?.Invoke(this);
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction) {
        _movement.ChangeDirection(direction);
    }

    public void SetSide(int side) {
        _side = side;
    }

    public void OnDestroyRaft(IHealth target) {
        _movement.Moving = true;
        _attackingTarget = null;
        if (_animator != null) { _animator.SetBool("Moving", true); }
    }
}
