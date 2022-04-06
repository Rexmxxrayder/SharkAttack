using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSomething : MonoBehaviour {
    [SerializeField] GameObject _obj;
    [SerializeField] bool _instantiateOnStart = true;

    private void Start() {
        if (_instantiateOnStart) { Create(); }
    }

    public void Create() {
        Instantiate(_obj, transform.position, transform.rotation);

    }
}
