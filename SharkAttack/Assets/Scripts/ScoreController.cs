using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour {
    [SerializeField] int _score;
    [SerializeField] UnityEvent<int> _onScoreEarn;

    public event UnityAction<int> OnScoreEarn { add => _onScoreEarn.AddListener(value); remove => _onScoreEarn.RemoveListener(value); }

    public int Score => _score;

    void Start() {

    }

    void Update() {

    }

    void AddScore(int score) {
        _score += score;
        _onScoreEarn?.Invoke(score);
    }
}
