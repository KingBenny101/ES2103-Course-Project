using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public float ENERGY_THRESHOLD;

    public float TOTAL_ENERGY;
    public float TOTAL_SCORE;
    public float TOTAL_COST;
    public float TOTAL_AREA;
    public float TOTAL_EMISSION;

    private float[] WEIGHTS;

    public Score(float energyThreshold)
    {
        this.ENERGY_THRESHOLD = energyThreshold;
        this.TOTAL_ENERGY = 0f;
        this.TOTAL_SCORE = 0f;
        this.TOTAL_COST = 0f;
        this.TOTAL_AREA = 0f;
        this.TOTAL_EMISSION = 0f;
        this.WEIGHTS = new float[4];
        this.WEIGHTS[0] = 1f;
        this.WEIGHTS[1] = 1f;
        this.WEIGHTS[2] = 1f;
        this.WEIGHTS[3] = 1f;
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
        this.TOTAL_COST += ppCost;
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
        this.TOTAL_COST -= ppCost;
        this.TOTAL_AREA -= ppArea;
        this.TOTAL_EMISSION -= ppEmission;
    }

    public float calculateScore()
    {
        var te = this.TOTAL_ENERGY;
        var tc = this.TOTAL_COST;
        var ta = this.TOTAL_AREA;
        var tem = this.TOTAL_EMISSION;
        this.TOTAL_SCORE =
            this.WEIGHTS[0] * te
            + this.WEIGHTS[1] * tc
            + this.WEIGHTS[2] * ta
            + this.WEIGHTS[3] * tem;
        return this.TOTAL_SCORE;
    }

    public bool isCompleted()
    {
        if (this.TOTAL_ENERGY >= this.ENERGY_THRESHOLD)
        {
            return true;
        }
        return false;
    }
}
