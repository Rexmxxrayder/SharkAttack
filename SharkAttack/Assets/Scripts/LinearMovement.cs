using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class LinearMovement : MonoBehaviour {
    [SerializeField] Transform _parent;
    [SerializeField] Vector3 _direction;
    [SerializeField] float _speed;
    [SerializeField] bool _moving = true;

    #region Properties

    public bool Moving { get => _moving; set => _moving = value; }

    #endregion

    void Start() {
        //ChangeDirection(_direction);
    }

    void FixedUpdate() {
        if (_moving) {
            _parent.transform.position += _parent.transform.forward * _speed;
        }
    }

    public void ChangeDirection(Vector3 direction) {
        _parent.transform.rotation = Quaternion.LookRotation(direction, _parent.transform.up);
    }
}
