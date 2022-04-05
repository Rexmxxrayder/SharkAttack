using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IHealth {
    int Health { get; }

    void LoseLife(int amount);
    void Death();

    event UnityAction<IHealth, int> OnHit;
    event UnityAction<IHealth> OnDeath;
}
