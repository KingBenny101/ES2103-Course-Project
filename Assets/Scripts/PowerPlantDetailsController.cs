using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerPlantDetailsController
{
    private MainGrid GRID;

    private GameObject SCOREBOARD;

    private Sprite SOLAR_PP_IM;
    private Sprite WIND_PP_IM;
    private Sprite GEOTHERMAL_PP_IM;
    private Sprite HYDRO_PP_IM;
    private Sprite THERMAL_PP_IM;
    private Sprite NUCLEAR_PP_IM;

    public PowerPlantDetailsController(MainGrid grid, GameObject scoreBoard)
    {
        this.GRID = grid;
        this.SCOREBOARD = scoreBoard;
        this.SOLAR_PP_IM = grid.SOLAR_IM;
        this.WIND_PP_IM = grid.WIND_IM;
        this.GEOTHERMAL_PP_IM = grid.GEOTHERMAL_IM;
        this.HYDRO_PP_IM = grid.HYDRO_IM;
        this.THERMAL_PP_IM = grid.THERMAL_IM;
        this.NUCLEAR_PP_IM = grid.NUCLEAR_IM;
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
        scoreBoardScore.GetComponent<UnityEngine.UI.Text>().text = $@"Score : {this.GRID.SCORE.calculateScore().ToString()}";

        GameObject powerPlantPreview = this.SCOREBOARD.transform.GetChild(1).gameObject;
        switch(id){
            case 1:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.SOLAR_PP_IM;

            break;
            case 2:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.WIND_PP_IM;

            break;
            case 3:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.GEOTHERMAL_PP_IM;

            break;
            case 4:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.HYDRO_PP_IM;
            break;
            case 5:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.THERMAL_PP_IM;

            break;
            case 6:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.NUCLEAR_PP_IM;

            break;
        }
    }
}
