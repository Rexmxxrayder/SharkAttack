using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isle : MonoBehaviour {
    [SerializeField] public string isleName;
    [SerializeField] public bool unlock;
    [SerializeField] public int highScore;
    [SerializeField] public int scoreOneStar;
    [SerializeField] public int scoreTwoStar;
    [SerializeField] public int scoreThreeStar;

    private void Start() {
        isleName = gameObject.name;
        highScore = PlayerPrefs.GetInt(name + " highScore");
        unlock = PlayerPrefs.GetInt(name + " locked") == 1 ? true : false;
        UpdateVisual();
    }

    void UpdateVisual() {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
        if (!unlock) {
            transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        } else
        if (scoreOneStar > highScore) {
            transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        } else
        if (scoreTwoStar > highScore) {
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        } else
        if (scoreThreeStar > highScore) {
            transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        } else {
            transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
        }
    }
}
