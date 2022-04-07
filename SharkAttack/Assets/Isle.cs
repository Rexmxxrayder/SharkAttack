using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Isle : MonoBehaviour {
    public LevelData levelData;
    public Isle nextIsle;


    public void Start() {
        levelData.isleName = gameObject.name;
        levelData.highScore = PlayerPrefs.GetInt(levelData.isleName + " highScore");
        levelData.isUnlock = PlayerPrefs.GetInt(levelData.isleName + " isUnlock") == 1 ? true : false;
        if (levelData.AlwaysUnlock) levelData.isUnlock = true;
        if (levelData.isUnlock && levelData.highScore >= levelData.scoreOneStar) {
            UnlockNextIsle();
        }
        UpdateIsle();
    }

    public void UpdateIsle() {
        if (levelData.AlwaysUnlock) levelData.isUnlock = true;
        if (levelData.isUnlock && levelData.highScore > levelData.scoreOneStar) {
            UnlockNextIsle();
        }
        GetComponent<Button>().enabled = levelData.isUnlock;
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
        if (!levelData.isUnlock) {
            transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        } else
        if (levelData.scoreOneStar > levelData.highScore) {
            transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        } else
        if (levelData.scoreTwoStar > levelData.highScore) {
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        } else
        if (levelData.scoreThreeStar > levelData.highScore) {
            transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        } else {
            transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
        }
    }

    public void UnlockNextIsle() {
        if (nextIsle == null) return;
        nextIsle.levelData.isUnlock = true;
        nextIsle.levelData.SaveData();
        nextIsle.Start();
    }
}
