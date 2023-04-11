using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereCollision : MonoBehaviour
{

    public bool noMoreCollision = true;
    public Cars car;

    public TextMeshProUGUI text;

    private bool roadPointsFirstCollision = true;

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

                //from here
                /*   for (int i = 0; i < RoadPathFollow.instance.roadPathPoints.Length; i++)
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
                   }*/
                //till here

                if (roadPointsFirstCollision)
                {
                    car.index = other.GetComponent<RoadPoint>().pointNumber;
                    roadPointsFirstCollision = false;
                   // text.text = other.GetComponent<RoadPoint>().pointNumber.ToString();
                }

                if (car.mouseTutorial != null)
                {
                    car.mouseTutorial.SetActive(false);
                }

            }
        }
    }
}
