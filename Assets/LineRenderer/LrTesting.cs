using System.Collections;
using UnityEngine;


public class LrTesting : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController line;


    private void Start()
    {
        line.SetUpLine(points);
    }

}