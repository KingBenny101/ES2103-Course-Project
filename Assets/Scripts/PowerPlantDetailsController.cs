using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantDetailsController
{
    private MainGrid GRID;

    private GameObject SCOREBOARD;

    public PowerPlantDetailsController(MainGrid grid, GameObject scoreBoard)
    {
        this.GRID = grid;
        this.SCOREBOARD = scoreBoard;
    }

    public void updateScoreBoard(PowerPlant pp)
    {
        GameObject scoreBoardText = this.SCOREBOARD.transform.GetChild(0).gameObject;
        var id = this.GRID.SelectedPowerPlant;

        var ppType = "Empty";


        switch (id)
        {
            case 1:
                ppType = "Solar";
                break;
            
            case 2:
                ppType = "Wind";
                break;
            
            case 3:
                ppType = "Geo-Thermal";
                break;
            
            case 4:
                ppType = "Hydro";
                break;
            
            case 5:
                ppType = "Thermal";
                break;
            
            case 6:
                ppType = "Nuclear";
                break;
        }
        string score = $@"
        PowerPlant Type : {ppType}\n
        PowerPlant Energy : {pp.ENERGY}\n
        PowerPlant Area : {pp.AREA}\n
        PowerPlant Cost : {pp.COST}\n
        PowerPlant Emission : {pp.EMISSION}";
        scoreBoardText.GetComponent<UnityEngine.UI.Text>().text = score;
    }
}
