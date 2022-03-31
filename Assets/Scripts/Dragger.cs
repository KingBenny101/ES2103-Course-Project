using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector3 _dragOffset;

    public Vector3 Max;
    public Vector3 Min;

    public GameController GC;



    void OnMouseDown(){
        _dragOffset = transform.position - GetMousePos();
        GC.LastSelected = this.gameObject;
    } 

    void OnMouseDrag() {

        Vector3 pos = GetMousePos() + _dragOffset;
        Vector3 newPos = Vector3.zero;
        pos.x = Mathf.Clamp(pos.x,Min.x,Max.x);
        pos.y = Mathf.Clamp(pos.y,Min.y,Max.y);

        transform.position = pos;        
        
    }
    
    Vector3 GetMousePos(){
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        return mousePos;
    }
}