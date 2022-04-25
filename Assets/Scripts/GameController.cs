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

    public GameObject GridContainer;
    public GameObject scoreBoard;


    private MainGrid grid;


    public void Start()
    {
        if (Panel)
        {

            Panel = GameObject.Find("Panel");
            Panel.SetActive(false);

        }

        grid = new MainGrid(34, 34, 0.206250f, GridContainer);

    }


    public void CreateNewPowerPlant(int choice)
    {
        GameObject go;
        if (choice == 1)
        {
            go = GameObject.Instantiate(PowerPlantSolar);
            go.GetComponent<Dragger>().powerPlantId = choice;
        }

        else if (choice == 2)
        {
            go = GameObject.Instantiate(PowerPlantWind);
            go.GetComponent<Dragger>().powerPlantId = choice;

        }
        else if (choice == 3)
        {
            go = GameObject.Instantiate(PowerPlantGeoThermal);
            go.GetComponent<Dragger>().powerPlantId = choice;

        }
        else if (choice == 4)
        {
            go = GameObject.Instantiate(PowerPlantHydro);
            go.GetComponent<Dragger>().powerPlantId = choice;

        }
        else if (choice == 5)
        {
            go = GameObject.Instantiate(PowerPlantNuclear);
            go.GetComponent<Dragger>().powerPlantId = choice;


        }
        else
        {
            go = GameObject.Instantiate(PowerPlantThermal);
            go.GetComponent<Dragger>().powerPlantId = choice;

        }
        go.transform.SetParent(Main);
        go.transform.localScale = new Vector3(0.035F, 0.035F, 1);
        go.GetComponent<Dragger>().GC = GC;
        go.GetComponent<Dragger>().gridSize = GridContainer.GetComponent<SpriteRenderer>().bounds.size.x;
        go.GetComponent<Dragger>().gridCellCount = GridContainer.GetComponent<Dragger>().gridCellCount;
        go.GetComponent<Dragger>().GridContainer = GridContainer.GetComponent<SpriteRenderer>();
        go.GetComponent<Dragger>().grid = grid;
        go.GetComponent<Dragger>().scoreBoard = scoreBoard;


        Vector3 _Offset = go.GetComponent<SpriteRenderer>().size;        

        go.GetComponent<Dragger>().Max.x = GridContainer.GetComponent<SpriteRenderer>().bounds.extents.x - _Offset.x * 0.5f;
        go.GetComponent<Dragger>().Min.y = -GridContainer.GetComponent<SpriteRenderer>().bounds.extents.y + _Offset.y;

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
