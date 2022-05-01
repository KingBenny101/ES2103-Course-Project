using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenuController : MonoBehaviour

{
   
    public void PauseGame(){
        Debug.Log("Loading Main Menu.");
        SceneManager.LoadScene("MainMenu");
    }

    public void loadLevel(int level){
        Debug.Log($"Loading level {level}");
        Supreme.LEVEL_NUMBER = level;
        if(level == 1){
            SceneManager.LoadScene("Level1");
        }
                if(level == 2){
            SceneManager.LoadScene("Level2");
        }
                if(level == 3){
            SceneManager.LoadScene("Level3");
        }
                if(level == 4){
            SceneManager.LoadScene("Level4");
        }
                if(level == 5){
            SceneManager.LoadScene("Level5");
        }
    }
}
