using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regions
{
    private Vector3 originPosition;

    public Regions()
    {
        originPosition = Vector3.zero;
    }

    public bool level1(Vector3 pos, int rNo, float width, float height)
    {
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
                cy = 3.5f * Mathf.Sin(0.5f * x - 3.2f) + 6f; //desert
                if (y > cy)
                {
                    return true;
                }
                break;
            case 2:
                cy = Mathf.Cos(x + 5.5f) - 2.4f; //mountains
                if (y <= cy)
                {
                    return true;
                }
                break;
            case 3:
                cy = (-x) * Mathf.Sin(x - 2); //city
                if (y <= cy)
                {
                    return true;
                }
                break;
            case 4:
                cy = (-x) * Mathf.Sin(x - 2); //city
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 5:
                cy = (-x + 0.6f) * Mathf.Sin(x) + 2; //plains
                if (y >= cy)
                {
                    return true;
                }
                break;
            case 6:
                return true;
        }
        return false;
    }
}
