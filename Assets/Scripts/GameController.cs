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






    public void Start()
    {
        if (Panel)
        {

            Panel = GameObject.Find("Panel");
            Panel.SetActive(false);

        }

        MainGrid grid = new MainGrid(34, 34, 0.206250f, GridContainer);

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
        go.transform.localScale = new Vector3(0.035F, 0.035F, 1);
        go.GetComponent<Dragger>().GC = GC;
        go.GetComponent<Dragger>().gridSize = GridContainer.GetComponent<SpriteRenderer>().bounds.size.x;
        go.GetComponent<Dragger>().gridCellCount = GridContainer.GetComponent<Dragger>().gridCellCount;
        go.GetComponent<Dragger>().GridContainer = GridContainer.GetComponent<SpriteRenderer>();

        Vector3 _Offset = go.GetComponent<SpriteRenderer>().size;
        //go.GetComponent<Dragger>().Max.x = GridContainer.GetComponent<SpriteRenderer>().bounds.extents.x + GridContainer.GetComponent<Dragger>()._xOffsetMax;
        //go.GetComponent<Dragger>().Max.y = GridContainer.GetComponent<SpriteRenderer>().bounds.extents.y + GridContainer.GetComponent<Dragger>()._yOffsetMax;

        //go.GetComponent<Dragger>().Min.x = -GridContainer.GetComponent<SpriteRenderer>().bounds.extents.x + GridContainer.GetComponent<Dragger>()._xOffsetMin;
        //go.GetComponent<Dragger>().Min.y = -GridContainer.GetComponent<SpriteRenderer>().bounds.extents.y + GridContainer.GetComponent<Dragger>()._yOffsetMin;        

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
