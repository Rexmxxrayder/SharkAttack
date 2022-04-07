using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour {
    [SerializeField] Timer _timer;
    [SerializeField] List<Image> _images;
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] List<Color> _colors;

    void Start() {

    }

    void Update() {
        if (_timer == null) { return; }
        UpdateTimer(Mathf.FloorToInt(_timer.Time - _timer.CurrentTime), Mathf.CeilToInt(_timer.Time));
    }

    void UpdateTimer(int value, int max) {
        float perc = Mathf.InverseLerp(0, max, value);
        int index = Mathf.FloorToInt(Mathf.Lerp(0f, _colors.Count, perc));
        if (index == _colors.Count) {
            index--;
        }
        Color color = _colors[index];
        for (int i = 0; i < _images.Count; i++) {
            _images[i].color = color;
        }
        _slider.value = perc;
        _text.text = value.ToString();
    }
}
