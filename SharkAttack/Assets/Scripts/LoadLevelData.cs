using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelData : MonoBehaviour {
    [SerializeField] public LevelData Data;
    [SerializeField] Timer _timer;
    [SerializeField] EntitySpawner _sharkSpawner;
    [SerializeField] bool _loadDataOnStart;

    void Start() {
        if (_loadDataOnStart) { LoadData(Data); }
    }

    public void LoadData(LevelData data) {
        if (_timer != null) { _timer.Time = data.duration; }
        if (_sharkSpawner != null) { _sharkSpawner.SpawnTime = data.duration / (float)data.sharkNumber; }
        if (_sharkSpawner != null) { _sharkSpawner.SpawnObject.GetComponent<BasicBrain>().AttackCooldown = data.sharkAttackTime; }
    }
}
