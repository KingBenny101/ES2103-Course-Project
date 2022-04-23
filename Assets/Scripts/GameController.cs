using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameController : MonoBehaviour
{
    public GameObject Panel;
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
        // if (Panel != null)
        // {

        //     Panel = GameObject.Find("Panel");
        //     Panel.SetActive(false);

        // }

        MainGrid grid = new MainGrid(32,32,new Vector3(-3.3F,-2.7F,0F),0.206250f);

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
        go.GetComponent<Dragger>().gridSize = 6.6F;
        go.GetComponent<Dragger>().gridCellCount = 32;

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
        Panel.SetActive(true);
        Main.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game.");
        Time.timeScale = 1;
        Panel.SetActive(false);
        Main.gameObject.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Quitting to Main Menu.");
        Panel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }



}
