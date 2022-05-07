using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

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
    public GameObject END_GAME_CHOICE;
    public GameObject INVENTORY;
    private MainGrid grid;

    public Sprite SOLAR_IM,
        HYDRO_IM,
        WIND_IM,
        GEOTHERMAL_IM,
        NUCLEAR_IM,
        THERMAL_IM;

    private Timer t;
    public UnityEngine.UI.Text TimeDisplay;
    public UnityEngine.UI.Text EndGameChoiceDisplay;
    public Regions REGIONS;

    public void Start()
    {
        if (Panel)
        {
            Panel = GameObject.Find("Panel");
            Panel.SetActive(false);
        }

        GameOver.SetActive(false);
        END_GAME_CHOICE.SetActive(false);

        Sprite[] S = new Sprite[6];
        S[0] = this.SOLAR_IM;
        S[1] = this.WIND_IM;
        S[2] = this.GEOTHERMAL_IM;
        S[3] = this.HYDRO_IM;
        S[4] = this.THERMAL_IM;
        S[5] = this.NUCLEAR_IM;

        REGIONS = new Regions();

        //grid = new MainGrid(34, 34, 0.206250f, GridContainer, scoreBoardScore, S, REGIONS.level2);

        Debug.Log(Supreme.LEVEL_NUMBER);
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
                    REGIONS.level1,
                    new Score(135000, 150, 3, 0)
                );

                break;
            case 2:
                grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level2,
                    new Score(142000, 150, 3, 0)
                );
                break;
            case 3:
                grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level3,
                    new Score(150000, 160, 3, 0)
                );
                break;
            case 4:
                grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level4,
                    new Score(145000, 140, 3, 0)
                );
                break;
            case 5:
                grid = new MainGrid(
                    34,
                    34,
                    0.206250f,
                    GridContainer,
                    scoreBoardScore,
                    S,
                    REGIONS.level5,
                    new Score(150000, 140, 3, 0)
                );
                break;
        }

        t = new Timer(TimeDisplay, 300f);
        t.StartTime();

        var btn = INVENTORY.transform.GetChild(0).gameObject;
        var pp = btn.AddComponent<PowerPlant>();
        pp.Init(7, 5, 4000, 0.04f);

        btn = INVENTORY.transform.GetChild(1).gameObject;
        pp = btn.AddComponent<PowerPlant>();
        pp.Init(7, 3, 8180, 0.011f);

        btn = INVENTORY.transform.GetChild(2).gameObject;
        pp = btn.AddComponent<PowerPlant>();
        pp.Init(25, 0.75f, 23740, 0.122f);

        btn = INVENTORY.transform.GetChild(3).gameObject;
        pp = btn.AddComponent<PowerPlant>();
        pp.Init(8, 3, 10685, 0.024f);

        btn = INVENTORY.transform.GetChild(4).gameObject;
        pp = btn.AddComponent<PowerPlant>();
        pp.Init(25, 3.3f, 24000, 1.500f);

        btn = INVENTORY.transform.GetChild(5).gameObject;
        pp = btn.AddComponent<PowerPlant>();
        pp.Init(6, 15, 18000, 0.95f);
    }

    public void Update()
    {
        CheckFeasibilityAndUpdate();

        if ((this.grid.WIN && Time.timeScale == 1) || t.timerIsRunning == false)
        {
            if (Input.GetMouseButton(0) == false && this.grid.SCORE.isCompleted())
            {
                END_GAME_CHOICE.SetActive(true);
                Time.timeScale = 0;
                DisableEnableInventoryBtn(1);
                Debug.Log(this.grid.SCORE.isCompleted());
                this.grid.CLICKABLE = false;
            }
            else if(t.timerIsRunning == false) {
                ShowGameOverScreen(true);
            }
        }
        t.UpdateTime();
    }

    public void CheckFeasibilityAndUpdate()
    {
        int ind = INVENTORY.transform.childCount;
        ind -= 1;
        for (int i = 0; i < ind; i++)
        {
            var child = INVENTORY.transform.GetChild(i);

            if (
                child.GetComponent<PowerPlant>().COST > this.grid.SCORE.TOTAL_COST
                || child.GetComponent<PowerPlant>().EMISSION
                    > (this.grid.SCORE.EMISSION_THRESHOLD - this.grid.SCORE.TOTAL_EMISSION)
                || (this.grid.SCORE.TOTAL_ENERGY >= this.grid.SCORE.ENERGY_THRESHOLD)
            )
            {
                child.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
            else
            {
                child.GetComponent<UnityEngine.UI.Button>().interactable = true;
            }
        }
    }

    public void ContinueGame()
    {
        DisableEnableInventoryBtn(0);
        this.grid.CLICKABLE = true;
        this.grid.WIN = false;
        END_GAME_CHOICE.SetActive(false);
        t.StartTime();
    }

    public void DisableEnableInventoryBtn(int c)
    {
        switch (c)
        {
            case 1:
                foreach (Transform child in INVENTORY.transform)
                {
                    child.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                break;
            default:
                foreach (Transform child in INVENTORY.transform)
                {
                    child.GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
                break;
        }
    }

    public void ShowGameOverScreen(bool t = false)
    {
        GameOver.SetActive(true);
        Main.gameObject.SetActive(false);
        GameObject scoreDisplay = GameOver.transform.GetChild(0).transform.GetChild(1).gameObject;
        GameObject tableDisplay = GameOver.transform.GetChild(0).transform.GetChild(2).gameObject;

        if(t){
            scoreDisplay.transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "You Lost";
        }

        string n = "\n";
        scoreDisplay.GetComponent<UnityEngine.UI.Text>().text =
            $@"YOUR SCORE{n}{Mathf.Ceil(this.grid.SCORE.TOTAL_SCORE)}";
        tableDisplay.GetComponent<UnityEngine.UI.Text>().text =
            $@"Money spent{n}INR {Mathf.Ceil(this.grid.SCORE.COST_THRESHOLD - this.grid.SCORE.TOTAL_COST)} Cr{n}{n}Emission Rate{n}{Decimal.Round((decimal)this.grid.SCORE.TOTAL_EMISSION,2)} KG/3.6S";
    }

    public void CreateNewPowerPlant(int choice)
    {
        GameObject go;
        PowerPlant pp;
        GameObject btn;
        PowerPlant btnPP;
        float c,
            ar,
            e,
            em;
        switch (choice)
        {
            case 1:
                go = Instantiate(PowerPlantSolar);
                go.GetComponent<Dragger>().powerPlantId = choice;
                btn = INVENTORY.transform.GetChild(0).gameObject;
                pp = go.AddComponent<PowerPlant>();
                btnPP = btn.GetComponent<PowerPlant>();

                c = btnPP.COST;
                e = btnPP.ENERGY;
                em = btnPP.EMISSION;
                ar = btnPP.AREA;
                pp.Init(c, ar, e, em);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);

                break;
            case 2:
                go = Instantiate(PowerPlantWind);
                go.GetComponent<Dragger>().powerPlantId = choice;
                btn = INVENTORY.transform.GetChild(1).gameObject;
                pp = go.AddComponent<PowerPlant>();
                btnPP = btn.GetComponent<PowerPlant>();

                c = btnPP.COST;
                e = btnPP.ENERGY;
                em = btnPP.EMISSION;
                ar = btnPP.AREA;
                pp.Init(c, ar, e, em);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 3:
                go = Instantiate(PowerPlantGeoThermal);
                go.GetComponent<Dragger>().powerPlantId = choice;
                btn = INVENTORY.transform.GetChild(2).gameObject;
                pp = go.AddComponent<PowerPlant>();
                btnPP = btn.GetComponent<PowerPlant>();

                c = btnPP.COST;
                e = btnPP.ENERGY;
                em = btnPP.EMISSION;
                ar = btnPP.AREA;
                pp.Init(c, ar, e, em);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 4:
                go = Instantiate(PowerPlantHydro);
                go.GetComponent<Dragger>().powerPlantId = choice;
                btn = INVENTORY.transform.GetChild(3).gameObject;
                pp = go.AddComponent<PowerPlant>();
                btnPP = btn.GetComponent<PowerPlant>();

                c = btnPP.COST;
                e = btnPP.ENERGY;
                em = btnPP.EMISSION;
                ar = btnPP.AREA;
                pp.Init(c, ar, e, em);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            case 5:
                go = Instantiate(PowerPlantNuclear);
                go.GetComponent<Dragger>().powerPlantId = choice;
                btn = INVENTORY.transform.GetChild(4).gameObject;
                pp = go.AddComponent<PowerPlant>();
                btnPP = btn.GetComponent<PowerPlant>();

                c = btnPP.COST;
                e = btnPP.ENERGY;
                em = btnPP.EMISSION;
                ar = btnPP.AREA;
                pp.Init(c, ar, e, em);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
            default:
                go = Instantiate(PowerPlantThermal);
                go.GetComponent<Dragger>().powerPlantId = choice;
                btn = INVENTORY.transform.GetChild(5).gameObject;
                pp = go.AddComponent<PowerPlant>();
                btnPP = btn.GetComponent<PowerPlant>();

                c = btnPP.COST;
                e = btnPP.ENERGY;
                em = btnPP.EMISSION;
                ar = btnPP.AREA;
                pp.Init(c, ar, e, em);
                go.GetComponent<Dragger>().PP = pp;
                this.grid.SCORE.addPowerPlant(pp);
                break;
        }
        go.transform.SetParent(Main);
        go.transform.localScale = new Vector3(0.035F, 0.035F, 1);
        go.GetComponent<Dragger>().GC = GC;
        go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
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
        go.GetComponent<BoxCollider2D>().size = new Vector2(7f, 7f);
        var pps = go.GetComponent<Dragger>();

        float maxX = go.GetComponent<Dragger>().Max.x;
        float minX = go.GetComponent<Dragger>().Min.x;
        float maxY = go.GetComponent<Dragger>().Max.y;
        float minY = go.GetComponent<Dragger>().Min.y;
        go.transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), 0);
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

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Quitting to Main Menu.");
        Panel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
