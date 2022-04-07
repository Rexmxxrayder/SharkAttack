using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraOnDrag : MonoBehaviour {
    [SerializeField] InputController _input;
    [SerializeField] ChooseCamera _cameraMovements;
    [SerializeField] float _minDistance = 2f;

    private void Reset() {
        _input = GetComponent<InputController>();
        _cameraMovements = GetComponent<ChooseCamera>();
    }

    void Awake() {
        if (_input != null) {
            _input.OnDrag += CameraMove;
        }
    }

    void OnDestroy() {
        if (_input != null) {
            _input.OnDrag += CameraMove;
        }
    }

    void CameraMove(Vector2 delta) {
        if (_cameraMovements == null) { return; }
        if (delta.sqrMagnitude < _minDistance * _minDistance) { return; }
        if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x)) { return; }
        if (delta.x < 0) { _cameraMovements.GoToLeft(); }
        else { _cameraMovements.GoToRight(); }
    }
}
