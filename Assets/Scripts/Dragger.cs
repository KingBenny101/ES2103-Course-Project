using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector3 _dragOffset;

    public Vector3 Max;
    public Vector3 Min;

    public GameController GC;

    public float gridSize;
    public int gridCellCount;

    public SpriteRenderer GridContainer;

    public float _xOffsetMax;
    public float _yOffsetMax;
    public float _xOffsetMin;
    public float _yOffsetMin;

    public MainGrid grid;
    public GameObject scoreBoard;

    public int powerPlantId;
    
    void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
        GC.LastSelected = this.gameObject;
        PowerPlantDetailsController ppdc = new PowerPlantDetailsController(grid,scoreBoard);
        grid.SelectedPowerPlant = powerPlantId;
        ppdc.updateScoreBoard();


    }

    void OnMouseDrag()
    {
        Vector3 pos = GetMousePos() + _dragOffset;
        Vector3 newPos = Vector3.zero;
        pos.x = Mathf.Clamp(pos.x, Min.x, Max.x);
        pos.y = Mathf.Clamp(pos.y, Min.y, Max.y);

        transform.position = pos;


        float gridCellSize;
        gridCellSize = gridSize / gridCellCount;

        var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x / gridSize * gridCellCount) * gridCellSize,
                                     Mathf.Round(currentPos.y / gridSize * gridCellCount) * gridCellSize,
                                     currentPos.z);

    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }


}