using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Parchemin : MonoBehaviour {
    [SerializeField] int scoreZeroStar = 0;
    [SerializeField] int scoreOneStar = 0;
    [SerializeField] int scoreTwoStar = 0;
    [SerializeField] int scoreThreeStar = 0;
    [SerializeField] TMP_Text score = null;
    [SerializeField] GameObject lights = null;
    [SerializeField] GameObject leftStar = null;
    [SerializeField] GameObject middleStar = null;
    [SerializeField] GameObject rightStar = null;
    [SerializeField] GameObject fail = null;
    [SerializeField] GameObject levelFinished = null;


    public void LaunchAnim(int score) {
        this.score.text = score.ToString();
        if(scoreZeroStar > score) {
            fail.SetActive(true);
            return;
        }
        lights.SetActive(true);
        leftStar.SetActive(true);
        levelFinished.SetActive(true);
        if (scoreOneStar > score) {
            return;
        }
        middleStar.SetActive(true);
        if (scoreTwoStar > score) {
            return;
        }
        rightStar.SetActive(true);
    }
}
