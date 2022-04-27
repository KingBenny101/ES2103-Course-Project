using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGrid
{
    private int width;
    private int height;
    private Vector3 gridStart;
    private float yOffset;
    private int[,] gridArray;
    private Vector3 originPosition = Vector3.zero;
    private Color[] regionColours;
    public int SelectedPowerPlant = -1;
    public Score SCORE;
    public GameObject SCOREBOARD_SCORE;

    public Sprite SOLAR_IM,HYDRO_IM, WIND_IM, GEOTHERMAL_IM,NUCLEAR_IM,THERMAL_IM;


    public MainGrid(int width, int height, float gridCellLength, GameObject gridContainer, GameObject scoreBoardScore, Sprite[] IM)
    {
        this.width = width;
        this.height = height;
        this.yOffset = gridContainer.GetComponent<Transform>().position.y;
        this.gridStart = originPosition - new Vector3(gridCellLength * 0.5F * width, gridCellLength * 0.5F * height - yOffset, 0);

        this.regionColours = new Color[6];
        this.regionColours[0] = Color.yellow;
        this.regionColours[1] = Color.blue;
        this.regionColours[2] = Color.red;
        this.regionColours[3] = Color.green;
        this.regionColours[4] = Color.black;
        this.regionColours[5] = Color.black;


        gridArray = new int[width, height];


        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                gridArray[i, j] = 1;
                Vector3 lineStart = new Vector3(gridStart.x + i * gridCellLength, gridStart.y + j * gridCellLength, 0);
                Vector3 lineEndX = new Vector3(gridStart.x + (i + 1) * gridCellLength, gridStart.y + j * gridCellLength, 0);
                Vector3 lineEndY = new Vector3(gridStart.x + i * gridCellLength, gridStart.y + (j + 1) * gridCellLength, 0);

                Color co;
                int inx;
                inx = 5;
                for(int c= 0; c<this.regionColours.GetLength(0);c++){
                    if(isInsideRegion(lineStart,c+1)){
                        inx = c;
                        break;
                    }
                }
                co = this.regionColours[inx];
                Draw.DrawLine(lineStart, lineEndX, co, 0.01f);
                Draw.DrawLine(lineStart, lineEndY, co, 0.01f);
            }
        }


        Vector3 gridEndY = new Vector3(gridStart.x + gridArray.GetLength(0) * gridCellLength, gridStart.y + gridArray.GetLength(1) * gridCellLength, 0);
        Draw.DrawLine(gridStart + new Vector3(gridArray.GetLength(0) * gridCellLength, 0, 0), gridEndY, Color.black, 0.01f);
        Vector3 gridEndX = new Vector3(gridStart.x, gridStart.y + gridArray.GetLength(1) * gridCellLength, 0);
        Draw.DrawLine(gridEndY, gridEndX, Color.black, 0.01f);
        this.SCORE = new Score(10f);
        this.SCOREBOARD_SCORE =scoreBoardScore;

        this.SOLAR_IM = IM[0];
        this.WIND_IM = IM[1];
        this.GEOTHERMAL_IM = IM[2];
        this.HYDRO_IM = IM[3];
        this.THERMAL_IM = IM[4];
        this.NUCLEAR_IM = IM[5];

    }

    public bool isInsideRegion(Vector3 pos, int rNo)
    {
        float x, y, cy;
        x = pos.x;
        y = pos.y;
        cy = 0f;
        if (x > originPosition.x + width / 2 || x < originPosition.x - width / 2 || y > originPosition.y + width / 2 || y < originPosition.y - width / 2)
            return false;
        switch (rNo)
        {
            case 1:
                cy = Mathf.Sin(x / 2 + 4) + 3f;
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 2:
                cy = Mathf.Sin(x / 2 + 4) + 2f;
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 3:
                cy = 1.5f * (1 - Mathf.Exp(-1f * (x + 3.5f)));
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 4:
                cy = -x * Mathf.Cos(x) - 2;
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 5:
                return true;
        }
        return false;
    }

    public int getColorSize(){
        return this.regionColours.GetLength(0);
    }

}
