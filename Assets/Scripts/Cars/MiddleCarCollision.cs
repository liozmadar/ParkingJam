using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCarCollision : MonoBehaviour
{
    //get the scripts components
    [Header("Get scripts components")]
    public Car car;
    public TouchCars touchCars;
    public GameObject mouseTutorial;

    [Header("Check the nearest RoadPath position")]
    public List<float> allPointsDistance;
    public bool checkAllPointsDistanceBool;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponentInParent<Car>();
        touchCars = GameObject.Find("GameCarsManager").GetComponent<TouchCars>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkAllPointsDistanceBool)
        {
            CheckTheDistanceBetweenAllRoadPoints();
            checkAllPointsDistanceBool = false;
        }
    }
    void GetIndex()
    {

    }
    void CheckTheDistanceBetweenAllRoadPoints()
    {
        for (int i = 0; i < RoadPathFollow.instance.roadPathPoints.Length; i++)
        {
            float dist = Vector3.Distance(RoadPathFollow.instance.roadPathPoints[i].transform.position, transform.position);
            allPointsDistance.Add(dist);


            if (i == RoadPathFollow.instance.roadPathPoints.Length)
            {
                Debug.Log("heyyy");
            }
        }

        index = allPointsDistance.IndexOf(Mathf.Min(allPointsDistance.ToArray()));
        Debug.Log(index);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NavMeshRoad")
        {
            car.touchCars.alreadyClicked = false;
            car.touchCars.cantTouchTheCar = true;
            touchCars.firstCarTutorial = false;
            car.carCanDrive = false;

            car.anim.enabled = false;
            //till here good
            if (mouseTutorial != null)
            {
                mouseTutorial.SetActive(false);
            }
            //
            //  car.carGoHomePath.enabled = true;
            touchCars.firstCarTutorial = false;

            car.moveTheCar = true;
            checkAllPointsDistanceBool = true;
            //untagged because if i click on one car and then release on another car , cause a bug . (because the cars not in the same tag)
            car.gameObject.tag = "Untagged";
        }
        if (other.gameObject.tag == "FinishLine")
        {
            car.touchCars.howManyCarsFinished++;
            car.gameObject.SetActive(false);
        }
    }
}
