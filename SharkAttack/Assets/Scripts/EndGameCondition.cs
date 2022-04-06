using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class EndGameCondition : MonoBehaviour {
    [SerializeField] Timer _time;
    [SerializeField] ParentShatterRaft _shatterRaft;

    private void Reset() {
        _time = GetComponent<Timer>();
    }

    void Start() {
        if (_time != null) { _time.OnTimerEnd += Win; }
        if (_shatterRaft != null) { _shatterRaft.OnLostChild += ComputeLose; }
    }

    void ComputeLose(int life) {
        this.Hurl();
        if (life <= 0) {
            Lose();
        }
    }

    void Win() {
        Debug.LogWarning("WOOOON");
        Time.timeScale = 0f;
    }

    void Lose() {
        Debug.LogWarning("LOOOOSE");
        Time.timeScale = 0f;
    }
}
