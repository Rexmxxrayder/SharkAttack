using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterRaft : MonoBehaviour {
    private void Start() {
        //transform.parent.GetComponent<ParentShatterRaft>().AddChild(this);
        GetComponent<HealthModule>().OnDeath += Die;
    }

    public void Die(IHealth healthModule) {
        //transform.parent.GetComponent<ParentShatterRaft>().RemoveChild(this);
        Destroy(gameObject);
    }
}
