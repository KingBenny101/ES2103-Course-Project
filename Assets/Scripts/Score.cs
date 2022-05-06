using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public float ENERGY_THRESHOLD;
    public float COST_THRESHOLD;
    public float EMISSION_THRESHOLD;
    public float TOTAL_ENERGY;
    public float TOTAL_SCORE;
    public float TOTAL_COST;
    public float TOTAL_AREA;
    public float TOTAL_EMISSION;
    public float INITIAL_EMISSION;



    public Score(float energyThreshold,float costThreshold, float emissionThreshold, float initialEmission)
    {
        this.ENERGY_THRESHOLD = energyThreshold;
        this.COST_THRESHOLD = costThreshold;
        this.EMISSION_THRESHOLD = emissionThreshold;
        this.TOTAL_ENERGY = 0f;
        this.TOTAL_SCORE = 0f;
        this.TOTAL_COST = costThreshold;
        this.TOTAL_AREA = 0f;
        this.TOTAL_EMISSION = initialEmission;
        this.INITIAL_EMISSION = initialEmission;

     
    }

    public void addPowerPlant(PowerPlant pp)
    {
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

        this.TOTAL_ENERGY += ppEnergy;
        this.TOTAL_COST -= ppCost;
        this.TOTAL_AREA += ppArea;
        this.TOTAL_EMISSION += ppEmission;
    }

    public void delPowerPlant(PowerPlant pp)
    {
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

        this.TOTAL_ENERGY -= ppEnergy;
        this.TOTAL_COST += ppCost;
        this.TOTAL_AREA -= ppArea;
        this.TOTAL_EMISSION -= ppEmission;
    }

    public float calculateScore()
    {
        var te = this.TOTAL_ENERGY;
        var tc = this.TOTAL_COST;
        var tem = this.TOTAL_EMISSION;
        var me = this.EMISSION_THRESHOLD;
        var mc = this.COST_THRESHOLD;
        var men = this.ENERGY_THRESHOLD;

        this.TOTAL_SCORE =
            2250*((te)/(men)) 
            + 1500 *((mc-tc)/(mc))
            + 1250 *((me-tem)/(me));
        return this.TOTAL_SCORE;
    }


    public bool isCompleted()
    {
        if (this.TOTAL_ENERGY >= this.ENERGY_THRESHOLD )
        {
            return true;
        }
        return false;
    }


}
