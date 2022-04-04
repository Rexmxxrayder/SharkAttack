using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovements : MonoBehaviour {
    [SerializeField] Vector3 _direction;
    [SerializeField] float _speed;

    void Start() {
        ChangeDirection(_direction);
    }

    void FixedUpdate() {
        transform.position += transform.forward * _speed;
    }

    public void ChangeDirection(Vector3 direction) {
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }
}
