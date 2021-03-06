using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    [SerializeField] LevelData mainLevelData;    
   public void GoToLevels() {
        SceneManager.LoadScene("Levels");
   }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void GoToProto() {
        SceneManager.LoadScene("F_ProtoScene");
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        if (mainLevelData.nextLevelData == null) GoToMenu();
        mainLevelData.nextLevelData.ExportData(mainLevelData);
        Reload();
    }

    public void StopTime() {
        Time.timeScale = 0;
    }

    public void StartTime() {
        Time.timeScale = 1;
    }
}
