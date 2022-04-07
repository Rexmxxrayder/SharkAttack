using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour {
    [SerializeField] int _score;
    [SerializeField] float _multiplicateur = 1f;
    [SerializeField] float _multiplicateurGain = 0.05f;
    [SerializeField] UnityEvent<int> _onScoreEarn;

    public event UnityAction<int> OnScoreEarn { add => _onScoreEarn.AddListener(value); remove => _onScoreEarn.RemoveListener(value); }

    public int Score => _score;

    void Start() {

    }

    void Update() {

    }

    public void ResetMult() {
        _multiplicateur = 1f;
    }

    public void AddScore(int score) {
        score = Mathf.CeilToInt(score * _multiplicateur);
        _multiplicateur += _multiplicateurGain;
        _score += score;
        _onScoreEarn?.Invoke(score);
    }
}
