using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isles : MonoBehaviour {
    public List<Isle> isles = new List<Isle>();
    public bool clear;

    public void Clear() {
        for (int i = 0; i < isles.Count; i++) {
            isles[i].highScore = 0;
            isles[i].isUnlock = false;
            isles[i].SaveData();
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
