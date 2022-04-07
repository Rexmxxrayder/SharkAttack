using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ToolsBoxEngine;

public class SharkSignal : MonoBehaviour {
    [SerializeField] EntitySpawner _spawner;
    [SerializeField] ChooseCamera _cameraBrain;
    [SerializeField] GameObject _leftSignal;
    [SerializeField] GameObject _rightSignal;

    [SerializeField] UnityEvent _onSignalActive;
    [SerializeField] UnityEvent _onSignalNotActive;

    void Update() {
        if (_spawner == null || _cameraBrain == null) { return; }
        if (_leftSignal == null || _rightSignal == null) { return; }
        int next = (_cameraBrain.CurrentCamera + 1) % 4, previous = ((_cameraBrain.CurrentCamera - 1) % 4 + 4) % 4;
        _leftSignal.SetActive(_spawner.SharkBySide[next] > 0);
        _rightSignal.SetActive(_spawner.SharkBySide[previous] > 0);
        if (_spawner.SharkBySide[next] > 0 || _spawner.SharkBySide[previous] > 0) {
            //_onSignalActive?.
        }
    }
}
