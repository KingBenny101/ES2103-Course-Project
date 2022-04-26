using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private float ENERGY_THRESHOLD;
    
    private float TOTAL_ENERGY;
    public float TOTAL_SCORE;
    private float TOTAL_COST;
    private float TOTAL_AREA;
    private float TOTAL_EMISSION;
    
    private float[] WEIGHTS;

    public Score(float energyThreshold){
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

    public void addPowerPlant(PowerPlant pp){
    
        this.TOTAL_ENERGY += pp.ENERGY;
        this.TOTAL_COST += pp.COST;
        this.TOTAL_AREA += pp.AREA;
        this.TOTAL_EMISSION += pp.EMISSION;

    }

    public void delPowerPlant(PowerPlant pp){
        this.TOTAL_ENERGY -= pp.ENERGY;
        this.TOTAL_COST -= pp.COST;
        this.TOTAL_AREA -= pp.AREA;
        this.TOTAL_EMISSION -= pp.EMISSION;
    }

    public float calculateScore(){
        var te = this.TOTAL_ENERGY;
        var tc = this.TOTAL_COST;
        var ta = this.TOTAL_AREA;
        var tem = this.TOTAL_EMISSION;
        this.TOTAL_SCORE = this.WEIGHTS[0]*te +this.WEIGHTS[1]*tc + this.WEIGHTS[2]*ta + this.WEIGHTS[3]*tem;
        return this.TOTAL_SCORE;   
    }

}
