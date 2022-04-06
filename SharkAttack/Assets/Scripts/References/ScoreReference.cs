using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

[CreateAssetMenu(menuName = "References/ScoreReference")]
public class ScoreReference : Reference<ScoreController> {
    public void AddScore(int score) {
        if (Instance == null) { return; }
        Instance.AddScore(score);
    }
}
