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

    public void updateScoreBoard(PowerPlant pp, Vector3 curLoc)
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
        for (int c = 0; c < this.GRID.getColorSize(); c++)
        {
            if (this.GRID.isInsideRegion(curLoc, c + 1, this.GRID.width, this.GRID.height))
            {
                inx = c;
                break;
            }
        }

        switch (inx + 1)
        {
            case 1:
                // Dessert

                float fe,
                    fc;
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 0.8f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 0.6f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 0.8f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 0.7f;
                        fc = 1f;
                        break;
                }

                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;
            case 2:
                // River
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 0f;
                        fc = 1f;
                        break;
                }

                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;
            case 3:
                // Mountains
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 0.6f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 0.6f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 0.8f;
                        fc = 1f;
                        break;
                }

                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;
            case 4:
                // Plains
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 0.8f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 0.3f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 1f;
                        fc = 1f;
                        break;
                }

                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;
            case 5:
                // City
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 0.6f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 0.5f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 0f;
                        fc = 1f;
                        break;
                }
                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;
            case 6:
                // Mountains
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 0.6f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 0.6f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 0.8f;
                        fc = 1f;
                        break;
                }

                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;    
            case 7:
                // River
                fe = 1f;
                fc = 1f;
                switch (id)
                {
                    case 1:
                        // Solar
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 2:
                        // Wind
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 3:
                        // GeoThermal
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 4:
                        // Hydro
                        fe = 1f;
                        fc = 1f;
                        break;

                    case 5:
                        // Nuclear
                        fe = 0f;
                        fc = 1f;
                        break;

                    case 6:
                        // Thermal
                        fe = 0f;
                        fc = 1f;
                        break;
                }

                this.GRID.SCORE.delPowerPlant(pp);
                pp.setFactorValues(fc, 1f, fe, 1f);
                this.GRID.SCORE.addPowerPlant(pp);
                break;    
        }

        float ppEnergy,
            ppCost,
            ppArea,
            ppEmission;
        float[] ff;
        ff = pp.getPowerPlantValues();
        ppCost = ff[0];
        ppArea = ff[1];
        ppEnergy = ff[2];
        ppEmission = ff[3];

        string regionName = GetRegionFromId(inx);

        string score =
            $@"Current Region : {regionName}{n}Power Plant{n}Type : {ppType}{n}Energy : {ppEnergy}{n}Area : {ppArea}{n}Cost : {ppCost}{n}Emission : {ppEmission}";
        scoreBoardText.GetComponent<UnityEngine.UI.Text>().text = score;

        GameObject scoreBoardScore = this.GRID.SCOREBOARD_SCORE.transform.GetChild(0).gameObject;
        scoreBoardScore.GetComponent<UnityEngine.UI.Text>().text =
            $@"{n}Energy{n}{Mathf.Ceil(this.GRID.SCORE.TOTAL_ENERGY)}/{this.GRID.SCORE.ENERGY_THRESHOLD}{n}{n}Cost{n}{Mathf.Ceil(this.GRID.SCORE.TOTAL_COST)}/{this.GRID.SCORE.COST_THRESHOLD}{n}{n}Emission{n}{Mathf.Ceil(this.GRID.SCORE.TOTAL_EMISSION)}/{this.GRID.SCORE.EMISSION_THRESHOLD}";

        GameObject powerPlantPreview = this.SCOREBOARD.transform.GetChild(1).gameObject;
        switch (id)
        {
            case 1:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.SOLAR_PP_IM;

                break;
            case 2:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.WIND_PP_IM;

                break;
            case 3:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite =
                    this.GEOTHERMAL_PP_IM;

                break;
            case 4:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.HYDRO_PP_IM;
                break;
            case 5:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.NUCLEAR_PP_IM;

                break;
            case 6:
                powerPlantPreview.GetComponent<UnityEngine.UI.Image>().sprite = this.THERMAL_PP_IM;

                break;
        }
        powerPlantPreview.GetComponent<UnityEngine.UI.Image>().color = new Color(
            255,
            255,
            255,
            255
        );

        this.GRID.SCORE.calculateScore();
        if (this.GRID.SCORE.isCompleted())
        {
            this.GRID.WIN = true;
        }
    }

    private string GetRegionFromId(int id){
        string s;

        switch(id){
            case 0:
            s = "Desert";
            break;
            case 1:
            s = "Water";
            break;
            case 2:
            s = "Plateau";
            break;
            case 3:
            s = "Plains";
            break;
            case 4:
            s = "City";
            break;
            case 5:
            s = "Mountain";
            break;
            default:
            s = "Water";
            break;
        }
        return s;
    }
}
