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

    public void updateScoreBoard(PowerPlant pp,Vector3 curLoc)
    {
        GameObject scoreBoardText = this.SCOREBOARD.transform.GetChild(0).gameObject;
        var id = this.GRID.SelectedPowerPlant;

        var ppType = "Empty";
        var n = '\n';

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
        int inx;
        inx = 5;
        for(int c= 0; c<this.GRID.getColorSize();c++){
            if(this.GRID.isInsideRegion(curLoc,c+1)){
                inx = c;
                break;
            }
        }


        string score = $@"Current Region : {inx}{n}PowerPlant Type : {ppType}{n}PowerPlant Energy : {pp.ENERGY}{n}PowerPlant Area : {pp.AREA}{n}PowerPlant Cost : {pp.COST}{n}PowerPlant Emission : {pp.EMISSION}";
        scoreBoardText.GetComponent<UnityEngine.UI.Text>().text = score;

        GameObject scoreBoardScore = this.GRID.SCOREBOARD_SCORE.transform.GetChild(0).gameObject;
        scoreBoardScore.GetComponent<UnityEngine.UI.Text>().text = this.GRID.SCORE.calculateScore().ToString();
    }
}
