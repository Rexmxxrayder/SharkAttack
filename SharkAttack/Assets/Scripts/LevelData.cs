using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData")]
public class LevelData : ScriptableObject {
    public LevelData nextLevelData;
    public string isleName;
    public int highScore;
    public bool isUnlock;
    public bool AlwaysUnlock;
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
        ImportScore(score);
    }

    public void ImportScore(int newScore) {
        if (newScore > highScore) {
            highScore = newScore;
        }
        SaveData();
    }

    public void SaveData() {
        PlayerPrefs.SetInt(isleName + " highScore", highScore);
        PlayerPrefs.SetInt(isleName + " isUnlock", isUnlock == true ? 1 : 0);
    }

    public void ExportData(LevelData fromData) {
        fromData.nextLevelData = nextLevelData;
        fromData.isleName = isleName;
        fromData.highScore = highScore;
        fromData.isUnlock = isUnlock;
        fromData.AlwaysUnlock = AlwaysUnlock;
        fromData.sharkAttackTime = sharkAttackTime;
        fromData.scoreOneStar = scoreOneStar;
        fromData.scoreTwoStar = scoreTwoStar;
        fromData.scoreThreeStar = scoreThreeStar;
        fromData.sharkNumber = sharkNumber;
        fromData.duration = duration;
        fromData.sharkAttackTime = sharkAttackTime;
        fromData.killerWhaleHealthPoint = killerWhaleHealthPoint;
    }
}
