using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantDetailsController 
{
    private MainGrid GRID;

    private GameObject SCOREBOARD;

    public PowerPlantDetailsController(MainGrid grid, GameObject scoreBoard){
        this.GRID = grid;
        this.SCOREBOARD = scoreBoard;
    }

    public void updateScoreBoard(){
        GameObject scoreBoardText = this.SCOREBOARD.transform.GetChild(0).gameObject;
        scoreBoardText.GetComponent<UnityEngine.UI.Text>().text = this.GRID.SelectedPowerPlant.ToString();
    }
}
