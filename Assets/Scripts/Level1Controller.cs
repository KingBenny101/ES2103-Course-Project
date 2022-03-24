using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Controller : MonoBehaviour
{
     public void PauseGame(){
        Debug.Log("Loading Main Menu.");
        SceneManager.LoadScene("MainMenu");
    }
    
}
