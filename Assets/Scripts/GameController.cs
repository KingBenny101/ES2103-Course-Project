using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameController : MonoBehaviour
{
    GameObject panel;
    GameObject grid;

    public GameObject gridChild;
    public int gridChildCount;

    public void Start(){
        panel = GameObject.Find("Panel");
        grid = GameObject.Find("Grid");
        panel.SetActive(false);


        
        for(int i = 1; i < gridChildCount;i++){
            Debug.Log($"Creating Object {i}");
            GameObject gc = Instantiate(gridChild);
            //decimal.transform.parent = grid.transform;
        }
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
