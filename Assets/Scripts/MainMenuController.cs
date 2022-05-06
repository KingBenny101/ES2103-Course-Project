using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void SelectLevel()
    {
        Debug.Log("Starting Game.");
        SceneManager.LoadScene("LevelSelection");
    }

    public void HowToPlay()
    {
        Debug.Log("Loading HowToPlay.");
        SceneManager.LoadScene("HowToPlay");
    }

        public void About()
    {
        Debug.Log("Loading About.");
        SceneManager.LoadScene("About");
    }


    public void QuitGame()
    {
        Debug.Log("Quiting Game.");
        Application.Quit();
    }
}
