using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Panel;
    public GameObject GameOver;
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
    public GameObject scoreBoardScore;
    private MainGrid grid;

    public Sprite SOLAR_IM,
        HYDRO_IM,
        WIND_IM,
        GEOTHERMAL_IM,
        NUCLEAR_IM,
        THERMAL_IM;

    private Timer t;
    public UnityEngine.UI.Text TimeDisplay;

    public Regions REGIONS;

    public void Start()
    {
        if (Panel)
        {
            Panel = GameObject.Find("Panel");
            Panel.SetActive(false);
        }

        GameOver.SetActive(false);

        Sprite[] S = new Sprite[6];
        S[0] = this.SOLAR_IM;
        S[1] = this.WIND_IM;
        S[2] = this.GEOTHERMAL_IM;
        S[3] = this.HYDRO_IM;
        S[4] = this.THERMAL_IM;
        S[5] = this.NUCLEAR_IM;

        REGIONS = new Regions();

        grid = new MainGrid(34, 34, 0.206250f, GridContainer, scoreBoardScore, S, REGIONS.level1);

        switch (Supreme.LEVEL_NUMBER)
        {
            case 1:
                grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level1
                );
                Debug.Log("REGIONS 1");

                break;
            case 2:
                grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level2
                );
                Debug.Log("REGIONS 2");
                break;
            case 3:
                            grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level3
                );
                Debug.Log("REGIONS 3");
                break;
            case 4:
                            grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level4
                );
                Debug.Log("REGIONS 4");
                break;
            case 5:
                            grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level5
                );
                Debug.Log("REGIONS 5");
                break;
        }

        t = new Timer(TimeDisplay, 1000f);
        t.StartTime();
    }

    public void Update()
    {
        if ((this.grid.WIN && Time.timeScale == 1) || t.timerIsRunning == false)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
            Main.gameObject.SetActive(false);

            GameObject scoreDisplay = GameOver.transform
                .GetChild(0)
                .transform.GetChild(1)
                .gameObject;
            GameObject tableDisplay = GameOver.transform
                .GetChild(0)
                .transform.GetChild(2)
                .gameObject;

            string n = "\n";
            scoreDisplay.GetComponent<UnityEngine.UI.Text>().text =
                $@"YOUR SCORE{n}{this.grid.SCORE.TOTAL_SCORE}";
            tableDisplay.GetComponent<UnityEngine.UI.Text>().text =
                $@"Money spent{n}INR {this.grid.SCORE.TOTAL_COST}{n}{n}LAND Occupied{n}{this.grid.SCORE.TOTAL_AREA} Acre{n}{n}Emissions{n}{this.grid.SCORE.TOTAL_EMISSION} KG/Kwh";
        }
        t.UpdateTime();
    }

    public void CreateNewPowerPlant(int choice)
    {
        GameObject go;
        PowerPlant pp;
        switch (choice)
        {
            case 1:
                go = Instantiate(PowerPlantSolar);
                go.GetComponent<Dragger>().powerPlantId = choice;
                pp = new PowerPlant(1, 2, 3, 4);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 2:
                go = Instantiate(PowerPlantWind);
                go.GetComponent<Dragger>().powerPlantId = choice;
                pp = new PowerPlant(5, 6, 7, 8);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 3:
                go = Instantiate(PowerPlantGeoThermal);
                go.GetComponent<Dragger>().powerPlantId = choice;
                pp = new PowerPlant(9, 10, 11, 12);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 4:
                go = Instantiate(PowerPlantHydro);
                go.GetComponent<Dragger>().powerPlantId = choice;
                pp = new PowerPlant(13, 14, 15, 16);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 5:
                go = Instantiate(PowerPlantNuclear);
                go.GetComponent<Dragger>().powerPlantId = choice;
                pp = new PowerPlant(17, 18, 19, 20);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            default:
                go = Instantiate(PowerPlantThermal);
                go.GetComponent<Dragger>().powerPlantId = choice;
                pp = new PowerPlant(21, 22, 23, 24);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
        }
        go.transform.SetParent(Main);
        go.transform.localScale = new Vector3(0.035F, 0.035F, 1);
        go.GetComponent<Dragger>().GC = GC;
        go.GetComponent<Dragger>().gridSize = GridContainer
            .GetComponent<SpriteRenderer>()
            .bounds.size.x;
        go.GetComponent<Dragger>().gridCellCount = GridContainer
            .GetComponent<Dragger>()
            .gridCellCount;
        go.GetComponent<Dragger>().GridContainer = GridContainer.GetComponent<SpriteRenderer>();
        go.GetComponent<Dragger>().grid = grid;
        go.GetComponent<Dragger>().scoreBoard = scoreBoard;

        Vector3 _Offset = go.GetComponent<SpriteRenderer>().size;

        go.GetComponent<Dragger>().Max.x =
            GridContainer.GetComponent<SpriteRenderer>().bounds.extents.x - _Offset.x * 0.5f;
        go.GetComponent<Dragger>().Min.y =
            -GridContainer.GetComponent<SpriteRenderer>().bounds.extents.y + _Offset.y;
        go.GetComponent<BoxCollider2D>().size = new Vector2(4f, 4f);
        var pps = go.GetComponent<Dragger>();
        pps.setAndUpdatePP();
    }

    public void DeletePowerPlant()
    {
        Destroy(LastSelected);
        var pp = LastSelected.GetComponent<Dragger>().PP;
        this.grid.SCORE.delPowerPlant(pp);
        var pps = LastSelected.GetComponent<Dragger>();
        pps.setAndUpdatePP();
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
