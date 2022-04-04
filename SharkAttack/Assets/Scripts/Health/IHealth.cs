using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth {
    int Health { get; }

    void LoseLife(int amount);
    void Death();
}
