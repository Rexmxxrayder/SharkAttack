using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayHit : MonoBehaviour {
    [SerializeField] InputController _input;

    [SerializeField] Camera _camera;
    [SerializeField] ChooseCamera _cameraBrain;
    [SerializeField] LayerMask _hittable;

    private void Reset() {
        _camera = GetComponent<Camera>();
        _input = GetComponent<InputController>();
    }

    private void Awake() {
        if (_input != null) {
            _input.OnClick += CameraRay;
        }
    }

    private void OnDestroy() {
        if (_input != null) {
            _input.OnClick -= CameraRay;
        }
    }

    public void CameraRay(Vector2 position) {
        Ray ray = _camera?.ScreenPointToRay(position) ?? Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _hittable)) {
            Collide(hit.collider.gameObject);
        }
    }

    public void Collide(GameObject obj) {
        if ((obj.GetComponent<BasicBrain>()?.Side ?? -1) == _cameraBrain.CurrentCamera) {
            obj.GetComponent<IHealth>()?.LoseLife(1);
        }
    }
}
