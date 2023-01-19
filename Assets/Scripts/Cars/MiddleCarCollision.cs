using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCarCollision : MonoBehaviour
{
    public Car car;
    public TouchCars touchCars;

    public GameObject mouseTutorial;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponentInParent<Car>();
        touchCars = GameObject.Find("GameCarsManager").GetComponent<TouchCars>();
    }

    // Update is called once per frame
    void Update()
    {

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
            if (mouseTutorial != null)
            {
            mouseTutorial.SetActive(false);
            }
            car.carGoHomePath.enabled = true;
            touchCars.firstCarTutorial = false;
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
