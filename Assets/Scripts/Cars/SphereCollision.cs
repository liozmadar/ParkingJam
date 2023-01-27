using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{

    public bool noMoreCollision = true;
    public Cars car;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (noMoreCollision)
        {
            if (other.gameObject.tag == "RoadPathPoint")
            {
                car.carCanDrive = false;
                car.carCanDriveBackward = false;
                car.moveTheCar = true;

                //Check the distance between all road points
                for (int i = 0; i < RoadPathFollow.instance.roadPathPoints.Length; i++)
                {
                    float dist = Vector3.Distance(RoadPathFollow.instance.roadPathPoints[i].transform.position, transform.position);
                    car.allPointsDistance.Add(dist);
                }
                //index is the start point for the car to start the RoadPath from
                car.index = car.allPointsDistance.IndexOf(Mathf.Min(car.allPointsDistance.ToArray()));
                //
                noMoreCollision = false;

                if (car.mouseTutorial != null)
                {
                    car.mouseTutorial.SetActive(false);
                }
            }
        }
    }
}
