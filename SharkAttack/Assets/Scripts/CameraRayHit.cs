using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ToolsBoxEngine;

public class CameraRayHit : MonoBehaviour {
    [SerializeField] InputController _input;

    [SerializeField] Camera _camera;
    [SerializeField] ChooseCamera _cameraBrain;
    [SerializeField] LayerMask _hittable;

    [SerializeField] UnityEvent<Vector3> _onMiss;

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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _hittable, QueryTriggerInteraction.Collide)) {
            Collide(hit);
        }
    }

    public void Collide(RaycastHit hit) {
        GameObject obj = hit.collider.gameObject;
        if ((obj.GetComponent<BasicBrain>()?.Side ?? -1) == _cameraBrain.CurrentCamera) {
            obj.GetComponent<IHealth>()?.LoseLife(1);
        } else if (obj.GetComponent<BasicBrain>() == null && obj.CompareTag("Trash")) {
            obj.GetComponent<IHealth>()?.LoseLife(1);
        } else {
            _onMiss?.Invoke(hit.point.Override(0f, Axis.Y));
        }
    }
}
