using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPathFollow : MonoBehaviour
{
    public static RoadPathFollow instance;

    public GameObject[] roadPathPoints;


    //New Way to add the roadPoints
    public List<GameObject> roadPathPoints2;
    public GameObject firstChild;
    public int ChildsCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        roadPathPoints = GameObject.FindGameObjectsWithTag("RoadPathPoint");

        // Debug.Log(transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        AddRoadPointsToTheList();
    }
    void AddRoadPointsToTheList()
    {
        if (ChildsCount < roadPathPoints.Length)
        {
            firstChild = this.gameObject.transform.GetChild(ChildsCount).gameObject;
            ChildsCount++;
            roadPathPoints2.Add(firstChild);
        }
    }
}
