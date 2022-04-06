using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    [SerializeField] float _time;
    [SerializeField] bool _launchOnStart = true;
    [SerializeField] UnityEvent _onTimerEnd;

    public event UnityAction OnTimerEnd;

    bool ended = false;
    float _timer;

    void Start() {
        if (_launchOnStart) { StartCoroutine(RTimer(_time)); }
    }

    IEnumerator RTimer(float time) {
        _timer = 0f;
        while (_timer < _time) {
            yield return new WaitForSeconds(1f);
            ++_timer;
        }
        _onTimerEnd?.Invoke();
    }

    void Update() {
        //if (ended) { return; }

        //if (_timer < _time) {
        //    _timer += Time.deltaTime;
        //} else {
        //    ended = true;
        //    OnTimerEnd?.Invoke();
        //}
    }
}
