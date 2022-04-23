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
    public MainGrid(int width, int height, float gridCellLength, GameObject gridContainer)
    {
        this.width = width;
        this.height = height;
        this.yOffset = gridContainer.GetComponent<Transform>().position.y;
        this.gridStart = originPosition - new Vector3(gridCellLength * 0.5F * width, gridCellLength * 0.5F * height - yOffset, 0);


        gridArray = new int[width, height];


        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                gridArray[i, j] = 1;
                Vector3 lineStart = new Vector3(gridStart.x + i * gridCellLength, gridStart.y + j * gridCellLength, 0);
                Vector3 lineEndX = new Vector3(gridStart.x + (i + 1) * gridCellLength, gridStart.y + j * gridCellLength, 0);
                Vector3 lineEndY = new Vector3(gridStart.x + i * gridCellLength, gridStart.y + (j + 1) * gridCellLength, 0);


                Draw.DrawLine(lineStart, lineEndX, Color.black, 0.01f);
                Draw.DrawLine(lineStart, lineEndY, Color.black, 0.01f);
            }
        }


        Vector3 gridEndY = new Vector3(gridStart.x + gridArray.GetLength(0) * gridCellLength, gridStart.y + gridArray.GetLength(1) * gridCellLength, 0);
        Draw.DrawLine(gridStart + new Vector3(gridArray.GetLength(0) * gridCellLength, 0, 0), gridEndY, Color.black, 0.01f);
        Vector3 gridEndX = new Vector3(gridStart.x, gridStart.y + gridArray.GetLength(1) * gridCellLength, 0);
        Draw.DrawLine(gridEndY, gridEndX, Color.black, 0.01f);

    }



}
