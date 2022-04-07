using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILife : MonoBehaviour {
    [SerializeField] HealthImage _healthImage;
    [SerializeField] Image _background;
    [SerializeField] List<Color> _color;

    void Start() {

    }

    void Update() {
        if (_healthImage.HealthLevel >= _color.Count) { return; }
        _background.color = _color[_healthImage.HealthLevel];
    }
}
