using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    [SerializeField] Camera _camera;

    private void Reset() {
        _camera = GetComponent<Camera>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = _camera?.ScreenPointToRay(mousePos) ?? Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Collide(hit.collider.gameObject);
            }
        }
    }

    public void Collide(GameObject obj) {
        obj.GetComponent<IHealth>()?.LoseLife(1);
    }
}
