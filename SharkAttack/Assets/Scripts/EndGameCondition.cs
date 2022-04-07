using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class EndGameCondition : MonoBehaviour {
    [SerializeField] Timer _time;
    [SerializeField] ParentShatterRaft _shatterRaft;
    [SerializeField] ScoreController scoreController;
    [SerializeField] LoadLevelData loadLevelData;
    [SerializeField] Parchemin parchemin;
    [SerializeField] GameObject PauseButton;

    private void Reset() {
        _time = GetComponent<Timer>();
    }

    void Start() {
        if (_time != null) { _time.OnTimerEnd += Win; }
        if (_shatterRaft != null) { _shatterRaft.OnLostChild += ComputeLose; }
    }

    void ComputeLose(int life) {
        if (life <= 0) {
            Lose();
        }
    }

    void Win() {
        loadLevelData.Data.ImportScore(scoreController.Score);
        parchemin.transform.parent.gameObject.SetActive(true);
        parchemin.LaunchAnim(scoreController.Score, loadLevelData.Data);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    void Lose() {
        parchemin.loose = true;
        loadLevelData.Data.ImportScore(scoreController.Score);
        parchemin.transform.parent.gameObject.SetActive(true);
        parchemin.LaunchAnim(scoreController.Score, loadLevelData.Data);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
}
