using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public void PauseGame()
    {
        Debug.Log("Loading Main Menu.");
        SceneManager.LoadScene("MainMenu");
    }

    public void loadLevel(int level)
    {
        Debug.Log($"Loading level {level}");
        Supreme.LEVEL_NUMBER = level;
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                break;
            case 4:
                SceneManager.LoadScene("Level4");
                break;
            case 5:
                SceneManager.LoadScene("Level5");
                break;
        }
    }
}
