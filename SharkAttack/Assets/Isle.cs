using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isle : MonoBehaviour {
    public LevelData levelData;
    public Isle nextIsle;
    public string isleName;
    public int highScore;
    public bool isUnlock;

    private void Start() {
        isleName = gameObject.name;
        highScore = PlayerPrefs.GetInt(isleName + " highScore");
        isUnlock = PlayerPrefs.GetInt(isleName + " isUnlock") == 1 ? true : false;
        UpdateVisual();
    }

    void UpdateVisual() {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
        if (!isUnlock) {
            transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        } else
        if (levelData.scoreOneStar > highScore) {
            transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        } else
        if (levelData.scoreTwoStar > highScore) {
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        } else
        if (levelData.scoreThreeStar > highScore) {
            transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        } else {
            transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
        }
    }

    public void ImportScore(int newScore) {
        if (newScore > highScore) {
            highScore = newScore;
            if (highScore > levelData.scoreOneStar) {
                UnlockNextIsle();
            }
            SaveData();
        }
    }

    public void ExportData(LevelData toExport) {
        toExport.isle = this;
        toExport.sharkAttackTime = levelData.sharkAttackTime;
        toExport.scoreOneStar = levelData.scoreOneStar;
        toExport.scoreTwoStar = levelData.scoreTwoStar;
        toExport.scoreThreeStar = levelData.scoreThreeStar;
        toExport.sharkNumber = levelData.sharkNumber;
        toExport.duration = levelData.duration;
        toExport.sharkAttackTime = levelData.sharkAttackTime;
        toExport.killerWhaleHealthPoint = levelData.killerWhaleHealthPoint;
    }

    public void UnlockNextIsle() {
        if (nextIsle == null) return;
        nextIsle.isUnlock = true;
        nextIsle?.SaveData();
    }

    public void SaveData() {
        PlayerPrefs.SetInt(isleName + " highScore", highScore);
        PlayerPrefs.SetInt(isleName + " isUnlock", isUnlock == true ? 1 : 0);
    }
}
