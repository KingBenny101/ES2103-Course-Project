using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Regions
{
    private Vector3 originPosition;

    public Regions()
    {
        originPosition = Vector3.zero;
    }

    public bool level1(Vector3 pos, int rNo, float width, float height)
    {
       // Debug.Log("From Region 1");
        float x,
            y,
            cy;
        x = pos.x;
        y = pos.y;
        cy = 0f;
        if (
            x > originPosition.x + width / 2
            || x < originPosition.x - width / 2
            || y > originPosition.y + width / 2
            || y < originPosition.y - width / 2
        )
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

    public bool level2(Vector3 pos, int rNo, float width, float height)
    {
       // Debug.Log("From Region 2");
        float x,
            y,
            cy,
            cy2;
        x = pos.x;
        y = pos.y;
        cy = 0f;
        if (
            x > originPosition.x + width / 2
            || x < originPosition.x - width / 2
            || y > originPosition.y + width / 2
            || y < originPosition.y - width / 2
        )
            return false;
        switch (rNo)
        {
            case 1:
                cy = 3.5f * Mathf.Sin(0.5f * x - 3.2f) + 6f; //desert
                if (y > cy)
                {
                    return true;
                }
                break;
            case 6:
                cy = Mathf.Cos(x + 5.5f) - 2.4f; //mountains
                if (y <= cy)
                {
                    return true;
                }
                break;
            case 5:
                cy = (-x) * Mathf.Sin(x - 2);
                cy2 =  Mathf.Cos(x + 5.5f) - 2.4f;//city
                if (y <= cy && y>= cy2)
                {
                    return true;
                }
                break;
            case 2:
                cy = (-x) * Mathf.Sin(x - 2);
                cy2 =(-x + 0.6f)*Mathf.Sin(x +4.5f)+2f; //city
                if (y >= cy&&y<=cy2)
                {
                    return true;
                }
                break;
            case 4:
                cy = (-x + 0.6f) * Mathf.Sin(x+4.5f) + 2f;
                cy2 = 3.5f * Mathf.Sin(0.5f * x - 3.2f) + 6f;//plains
                if (y >= cy&&y<=cy2)
                {
                    return true;
                }
                break;
            case 7:
                return false;
        }
        return false;
    }

    public bool level3(Vector3 pos, int rNo, float width, float height)
    {
        //Debug.Log("From Region 3");
        float x,
        y,
        cy,
        cy2;
        x = pos.x;
        y = pos.y;
        cy = 0f;
        if (
            x > originPosition.x + width / 2
            || x < originPosition.x - width / 2
            || y > originPosition.y + width / 2
            || y < originPosition.y - width / 2
        )
            return false;
        switch (rNo)
        {
       case 1:
                cy = Mathf.Sin(0.2f * x ) - 1.3f; //desert
                if (y < cy)
                {
                    return true;
                }
                break;
            case 6:
                cy = Mathf.Exp(1.5f*x) + 3f; //mountains
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 5:
                cy =  (2.171f*Mathf.Log(0.55f*x + 4f)) - 2.6f;
                cy2 = Mathf.Sin(0.2f * x ) - 1.3f;//city
                if (y <= cy && y>= cy2)
                {
                    return true;
                }
                break;
            case 3:
                cy = 2f + Mathf.Exp(x - 3f);
                cy2 = Mathf.Exp(1.5f*x) + 3f; //city
                if (y >= cy&&y<=cy2)
                {
                    return true;
                }
                break;
            case 4:
                cy =  (2.171f*Mathf.Log(0.55f*x + 4f)) - 2.6f;
                cy2 = 2f + Mathf.Exp(x - 3f);//plains
                if (y >= cy&&y<=cy2)
                {
                    return true;
                }
                break;
            case 7:
                return true;
        } 
        return false;
    }

    public bool level4(Vector3 pos, int rNo, float width, float height)
    {
       // Debug.Log("From Region 5");

        return true;
    }

    public bool level5(Vector3 pos, int rNo, float width, float height)
    {
        //Debug.Log("From Region 5");
        float x,
        y,
        cy,
        cy2;
        x = pos.x;
        y = pos.y;
        cy = 0f;
        if (
            x > originPosition.x + width / 2
            || x < originPosition.x - width / 2
            || y > originPosition.y + width / 2
            || y < originPosition.y - width / 2
        )
            return false;
        switch (rNo)
        {
       case 1:
                cy = 2.5f*Mathf.Asin(x-2.5f) + 1.5f; //desert
                if (y < cy)
                {
                    return true;
                }
                break;
            case 6:
                cy = -1f*(x+1f)*(x+1f) + 0.5f; //mountains
                if (y <= cy)
                {
                    return true;
                }
                break;
            case 3:
                cy2 = (float)(Math.Sinh(x+3));//city
                if (y>= cy2)
                {
                    return true;
                }
                break;
            case 4:
                cy =  (float)(Math.Cosh(1.2f*x -0.7f))+0.3f;
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 7:
               return true;    
        } 
        return false;
    }
}
