using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    LineRenderer lr;
    EdgeCollider2D ec;

    LandGenerater lG;

    List<Vector2> landPoss = new List<Vector2>();
    Vector2 lastPos;
    const float addPos = 40, maxLandCurve = -2.5f, minLandCurve = -3;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        ec = GetComponent<EdgeCollider2D>();
        lG = FindObjectOfType<LandGenerater>();
    }

    private void Start()
    {
        lastPos = lG.nextLandPos;
        landPoss.Add(new Vector2(lastPos.x - 40, lastPos.y));
        landPoss.Add(lastPos);
        for (int i = 0; i < 10; i++)
        {
            lastPos = new Vector2(lastPos.x + addPos, SetLandY(lastPos.y));
            landPoss.Add(lastPos);
        }
        lr.positionCount = landPoss.Count;
        for (int i = 0; i < landPoss.Count; i++)
        {
            lr.SetPosition(i, landPoss[i]);
        }
        ec.points = landPoss.ToArray();
        lG.GetLandPos = landPoss[landPoss.Count - 1]; 
    }

    private float SetLandY(float pos_y)
    {
        int randomNum = Random.Range(0, 6);
        if (randomNum == 2)
        {
            pos_y = maxLandCurve;
        }
        else
        {
            pos_y = minLandCurve;
        }
        return pos_y;
    }
}
