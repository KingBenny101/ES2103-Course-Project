using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant: MonoBehaviour  
{
    public float COST,
        AREA,
        ENERGY,
        EMISSION;
    private float COST_FC,
        AREA_FC,
        ENERGY_FC,
        EMISSION_FC;

    public void Init(float cost, float area, float energy, float emission)
    {
        this.COST = cost;
        this.AREA = area;
        this.ENERGY = energy;
        this.EMISSION = emission;
        this.COST_FC = 1f;
        this.AREA_FC = 1f;
        this.ENERGY_FC = 1f;
        this.EMISSION_FC = 1f;
    }

    public void setPowerPlantValues(float cost, float area, float energy, float emission)
    {
        this.COST = cost;
        this.AREA = area;
        this.ENERGY = energy;
        this.EMISSION = emission;
    }

    public void setFactorValues(float cost, float area, float energy, float emission)
    {
        this.COST_FC = cost;
        this.AREA_FC = area;
        this.ENERGY_FC = energy;
        this.EMISSION_FC = emission;
    }

    public float[] getPowerPlantValues()
    {
        float[] ff = new float[4];
        ff[0] = this.COST * this.COST_FC;
        ff[1] = this.AREA * this.AREA_FC;
        ff[2] = this.ENERGY * this.ENERGY_FC;
        ff[3] = this.EMISSION * this.EMISSION_FC;
        return ff;
    }
}
