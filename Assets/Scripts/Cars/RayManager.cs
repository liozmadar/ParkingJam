using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{

    //The raycast 
    [Header("The raycast")]
    public RaycastHit hitInfo;

    //The Cars script
    [Header("Get script component")]
    public Cars cars;

    //mouse input position
    [Header("Mouse position")]
    private float mousePositionStartX;
    private float mousePositionEndX;

    //Array of all the cars and finish line
    [Header("Finish line")]
    public GameObject[] carsFinished;
    public int howManyCarsFinished;

    public bool firstCarTutorial = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        CarsFinished();
    }
    void RayCast()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "Car" || hitInfo.transform.gameObject.tag == "FirstCarTutorial" || hitInfo.transform.gameObject.tag == "CarRight")
                {
                    var carScript = hitInfo.collider.GetComponent<Cars>();
                    cars = carScript;

                    mousePositionStartX = Input.mousePosition.x;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (hitInfo.transform.gameObject.tag == "FirstCarTutorial")//&& firstCarTutorial
            {
                mousePositionEndX = Input.mousePosition.x;
                if (mousePositionStartX > mousePositionEndX)
                {
                    cars.carCanDrive = true;
                    // alreadyClicked = true;
                }
                else if (mousePositionStartX < mousePositionEndX)
                {
                    cars.carCanDriveBackward = true;
                    //  alreadyClicked = true;

                }
            }
            else if (hitInfo.transform.gameObject.tag == "Car")//&& !firstCarTutorial
            {
                mousePositionEndX = Input.mousePosition.x;
                if (mousePositionStartX > mousePositionEndX)
                {
                    cars.carCanDrive = true;
                    //  alreadyClicked = true;
                }
                else if (mousePositionStartX < mousePositionEndX)
                {
                    cars.carCanDriveBackward = true;
                    //  alreadyClicked = true;
                }
            }
            else if (hitInfo.transform.gameObject.tag == "CarRight")// && !firstCarTutorial
            {
                mousePositionEndX = Input.mousePosition.x;
                if (mousePositionStartX < mousePositionEndX)
                {
                    cars.carCanDrive = true;
                    //  alreadyClicked = true;
                }
                else if (mousePositionStartX > mousePositionEndX)
                {
                    cars.carCanDriveBackward = true;
                    // alreadyClicked = true;
                }
            }
        }
    }
    void CarsFinished()
    {
        //check if all the cars are get to the finish line
        if (howManyCarsFinished == carsFinished.Length)
        {
            //end game card
           
        }
    }
}
