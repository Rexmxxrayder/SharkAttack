using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScore : MonoBehaviour {
    [SerializeField] ScoreController _score;
    [SerializeField] TextMeshProUGUI _text;

    void Start() {

    }

    void Update() {
        _text.text = _score.Score.ToString();
    }
}
