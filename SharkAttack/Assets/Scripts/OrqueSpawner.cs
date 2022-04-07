using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrqueSpawner : MonoBehaviour {
    [SerializeField] GameObject _orque;
    [SerializeField] EntitySpawner _spawner;

    [SerializeField] UnityEvent<GameObject> _onSpawn;

    public void SpawnOrque() {
        if (_spawner == null || _orque == null) { return; }
        GameObject last = _spawner.Spawn(_orque);
        _onSpawn?.Invoke(last);
    }
}
