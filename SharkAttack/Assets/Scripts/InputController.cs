using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class InputController : MonoBehaviour {
    [SerializeField] float _clickTime = 0.2f;

    float _timer = 0f;
    Vector2 _dragPosition = Vector2.zero;

    public System.Action<Vector2> OnClick;
    public System.Action<Vector2> OnDrag;

    void Update() {
        // Mouse
        if (Input.GetMouseButtonDown(0)) {
            _timer = 0f;
            _dragPosition = Input.mousePosition;
        } else if (Input.GetMouseButton(0)) {
            _timer += Time.deltaTime;
        } else if (Input.GetMouseButtonUp(0)) {
            if (_timer <= _clickTime) {
                OnClick?.Invoke(Input.mousePosition);
            } else {
                OnDrag?.Invoke(Input.mousePosition.To2D() - _dragPosition);
            }
        }

        // Touch
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                _timer = 0f;
                _dragPosition = Input.mousePosition;
            } else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                if (_timer <= _clickTime) {
                    OnClick?.Invoke(Input.mousePosition);
                } else {
                    OnDrag?.Invoke(Input.mousePosition.To2D() - _dragPosition);
                }
            } else {
                _timer += Time.deltaTime;
            }
        }
    }
}
