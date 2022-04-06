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
        SceneManager.LoadScene("ProtoScene");
    }

    public void ChangeDataLevel(LevelData isleData) {
        mainLevelData = isleData;
    }

}
