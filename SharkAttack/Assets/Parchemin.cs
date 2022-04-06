using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Parchemin : MonoBehaviour {
    [SerializeField] Isle isle;
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
        lights.SetActive(false);
        leftStar.SetActive(false);
        middleStar.SetActive(false);
        rightStar.SetActive(false);
        fail.SetActive(false);
        levelFinished.SetActive(false);
        this.score.text = score.ToString();
        if(scoreOneStar > score) {
            fail.SetActive(true);
            return;
        }
        lights.SetActive(true);
        leftStar.SetActive(true);
        levelFinished.SetActive(true);
        if (scoreTwoStar > score) {
            return;
        }
        middleStar.SetActive(true);
        if (scoreThreeStar > score) {
            return;
        }
        rightStar.SetActive(true);
    }
}
