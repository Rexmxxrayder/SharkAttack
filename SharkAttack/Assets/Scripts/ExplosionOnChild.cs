using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnChild : MonoBehaviour {
    [SerializeField] float explosionForce;
    [SerializeField] float explosionRadius;

    void Start() {
        Explosion();
    }

    void Explosion() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).GetComponent<Rigidbody>() != null) {
                transform.GetChild(i).GetComponent<Rigidbody>().AddExplosionForce(explosionForce, Random.insideUnitSphere * 1f + transform.position, explosionRadius);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
