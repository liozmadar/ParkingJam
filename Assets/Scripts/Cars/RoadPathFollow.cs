using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPathFollow : MonoBehaviour
{
    public static RoadPathFollow instance;

    public GameObject[] roadPathPoints;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
