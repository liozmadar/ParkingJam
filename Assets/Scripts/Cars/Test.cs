using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject lookAt;
    int nextPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextPosition < RoadPathFollow.instance.roadPathPoints.Length)
        {
            transform.LookAt(RoadPathFollow.instance.roadPathPoints[nextPosition].transform.position);

            if (transform.position == RoadPathFollow.instance.roadPathPoints[nextPosition].transform.position)
            {
                nextPosition++;
            }
        }
       
    }
}
