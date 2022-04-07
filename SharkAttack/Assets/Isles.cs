using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isles : MonoBehaviour {
    public List<Isle> isles = new List<Isle>();
    public bool clear;

    public void Clear() {
        for (int i = 0; i < isles.Count; i++) {
            isles[i].levelData.highScore = 0;
            isles[i].levelData.isUnlock = false;
            isles[i].levelData.SaveData();
            isles[i].Start();
        }
    }

    private void Update() {
        if (clear) {
            clear = false;
            Clear();
        }
    }
}
