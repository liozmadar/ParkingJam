using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    public static RayManager instance;
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
    public bool FinishTheStageBool;
    public int howManyCarsFinished;
    public int howManyCarsInScene;
    private GameObject[] allCarsInTheScene;
    private GameObject[] allCarsRightInTheScene;

    public bool firstCarTutorial = true;

    public int sceneLevel;
    public bool sceneLevelBool;

    public bool resetLevelsCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CheckHowManyCarsInTheScene();
        sceneLevel = PlayerPrefs.GetInt("sceneLevel");
        Debug.Log(howManyCarsFinished);
        Debug.Log(howManyCarsInScene);
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();

        if (!sceneLevelBool)
        {
            CarsFinished();
        }

        if (resetLevelsCount)
        {
            PlayerPrefs.DeleteAll();
        }
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
        if (!FinishTheStageBool)
        {
            //check if all the cars are get to the finish line
            if (howManyCarsFinished == howManyCarsInScene)
            {
                Debug.Log("hereooo");
                //end game card
                FinishTheStageBool = true;
                sceneLevelBool = true;
                sceneLevel++;
                PlayerPrefs.SetInt("sceneLevel", sceneLevel);
            }
        }
    }
    void CheckHowManyCarsInTheScene()
    {
        allCarsInTheScene = GameObject.FindGameObjectsWithTag("Car");
        allCarsRightInTheScene = GameObject.FindGameObjectsWithTag("CarRight");

        howManyCarsInScene += allCarsInTheScene.Length;
        howManyCarsInScene += allCarsRightInTheScene.Length;
    }
}
