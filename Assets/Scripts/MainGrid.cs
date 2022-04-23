using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGrid 
{   
    private int width;
    private int height;
    private int[,] gridArray;

    public MainGrid (int width,int height,Vector3 gridStart,float gridCellLength){
        this.width = width;
        this.height = height;
        gridArray = new int[width,height];


        for(int i = 0; i < gridArray.GetLength(0); i++){
            for(int j = 0; j < gridArray.GetLength(1);j++){
                gridArray[i,j] = 1;
                Vector3 lineStart = new Vector3(gridStart.x + i*gridCellLength,gridStart.y + j*gridCellLength,0);
                Vector3 lineEndX = new Vector3(gridStart.x + (i+1)*gridCellLength,gridStart.y + j*gridCellLength,0);
                Vector3 lineEndY = new Vector3(gridStart.x + i*gridCellLength,gridStart.y + (j+1)*gridCellLength,0);


                Debug.DrawLine(lineStart,lineEndX,Color.black,100f);
                Debug.DrawLine(lineStart,lineEndY,Color.black,100f);
                Debug.Log(lineStart);
            }
        }



    }


    
}
