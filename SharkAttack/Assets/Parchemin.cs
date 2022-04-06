using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Parchemin : MonoBehaviour {
    [SerializeField] TMP_Text score = null;
    [SerializeField] GameObject lights = null;
    [SerializeField] GameObject leftStar = null;
    [SerializeField] GameObject middleStar = null;
    [SerializeField] GameObject rightStar = null;
    [SerializeField] GameObject fail = null;
    [SerializeField] GameObject levelFinished = null;

    public void LaunchAnim(int score, LevelData data) {
        lights.SetActive(false);
        leftStar.SetActive(false);
        middleStar.SetActive(false);
        rightStar.SetActive(false);
        fail.SetActive(false);
        levelFinished.SetActive(false);
        this.score.text = score.ToString();
        if(data.scoreOneStar > score) {
            fail.SetActive(true);
            return;
        }
        lights.SetActive(true);
        leftStar.SetActive(true);
        levelFinished.SetActive(true);
        if (data.scoreTwoStar > score) {
            return;
        }
        middleStar.SetActive(true);
        if (data.scoreThreeStar > score) {
            return;
        }
        rightStar.SetActive(true);
    }
}
