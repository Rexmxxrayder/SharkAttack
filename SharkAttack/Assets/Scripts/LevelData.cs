using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData")]
public class LevelData : ScriptableObject {
    public Isle isle;
    [Header("Export")]
    [Header("UI")]
    public int scoreOneStar;
    public int scoreTwoStar;
    public int scoreThreeStar;
    [Header("Level")]
    public int sharkNumber;
    public float duration;
    public float sharkAttackTime;
    public int killerWhaleHealthPoint;

    public void ExportScore(int score) {
        isle.ImportScore(score);
    }
}
