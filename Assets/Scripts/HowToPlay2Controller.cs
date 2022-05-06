using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay2Controller : MonoBehaviour
{
    public void PauseGame()
    {
        Debug.Log("Loading Main Menu.");
        SceneManager.LoadScene("MainMenu");
    }
}
