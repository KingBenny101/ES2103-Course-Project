using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameController : MonoBehaviour
{
    GameObject panel;
    public GameObject PowerPlantSolar;
    public GameObject PowerPlantWind;
    public GameObject PowerPlantGeoThermal;
    public GameObject PowerPlantHydro;
    public GameObject PowerPlantNuclear;
    public GameObject PowerPlantThermal;

    public GameObject LastSelected;

    public GameController GC;

    public Transform Main;

    public void Start()
    {
        if (panel != null)
        {

            panel = GameObject.Find("Panel");
            panel.SetActive(false);

        }

    }


    public void CreateNewPowerPlant(int choice)
    {
        GameObject go;
        if (choice == 1)
        {
            go = GameObject.Instantiate(PowerPlantSolar);
        }

        else if (choice == 2)
        {
            go = GameObject.Instantiate(PowerPlantWind);
        }
        else if (choice == 3)
        {
            go = GameObject.Instantiate(PowerPlantGeoThermal);
        }
        else if (choice == 4)
        {
            go = GameObject.Instantiate(PowerPlantHydro);
        }
        else if (choice == 5)
        {
            go = GameObject.Instantiate(PowerPlantNuclear);
        }
        else
        {
            go = GameObject.Instantiate(PowerPlantThermal);
        }
        go.transform.SetParent(Main);
        go.GetComponent<Dragger>().GC = GC;
    }


    public void DeletePowerPlant()
    {
        Destroy(LastSelected);
        LastSelected = null;
    }


    public void PauseGame()
    {
        Debug.Log("Pausing Game.");
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game.");
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Quitting to Main Menu.");
        panel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }



}
