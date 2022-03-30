using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameController : MonoBehaviour
{
    GameObject panel;
    public GameObject PowerPlant;
    public Transform Main;

    public void Start(){
        panel = GameObject.Find("Panel");
        panel.SetActive(false);


    }


    public void CreateNewPowerPlant(){
        GameObject go  = GameObject.Instantiate(PowerPlant);
        go.transform.SetParent(Main);
    }


    public void PauseGame(){
        Debug.Log("Pausing Game.");
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void ResumeGame(){
        Debug.Log("Resuming Game.");
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void ExitToMainMenu(){
        Debug.Log("Quitting to Main Menu.");
        panel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
