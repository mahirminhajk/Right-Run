using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerater : MonoBehaviour
{
    [SerializeField] GameObject landPfab;
    Vector2 startPos = new Vector2(-10, -3);
    Vector2 lastLandpos;
    int n = 0;


    public Vector2 nextLandPos
    {
        get
        {
            if (n == 0) { n++; return new Vector2(-10, -3);  }
            else return getLandPos;
        }
    }

    private Vector2 getLandPos;
    public Vector2 GetLandPos { set { getLandPos = value; } get { return getLandPos; } }

    private void Start()
    {
        Gene();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Gene();
        }
    }

    private void Gene()
    {
        //TODO: need to change the spawn position to optinmaze the performes(player pos)
        GameObject land = Instantiate(landPfab, Vector2.zero, Quaternion.identity) as GameObject;
    }
}
