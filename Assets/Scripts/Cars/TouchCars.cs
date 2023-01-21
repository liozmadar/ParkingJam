using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TouchCars : MonoBehaviour
{
    //The raycast 
    [Header("The raycast")]
    public RaycastHit hitInfo;

    //The Cars script
    [Header("Get script component")]
    public Car car;

    //Check if i already click on any car , so i cant move the other cars
    [Header("Check car touching")]
    public bool alreadyClicked;
    public bool cantTouchTheCar = true;
    public bool firstCarTutorial = true;

    //Cars speed
    [Header("Cars speed")]
    public float speed;

    //Array of all the cars and finish line
    [Header("Finish line")]
    public GameObject[] carsFinished;
    public int howManyCarsFinished;
    public GameObject canvasFinishGame;
    public TextMeshProUGUI finishText;
    private bool stopFinishTextSize = true;

    //mouse input position
    [Header("Mouse position")]
    private float mousePositionStartX;
    private float mousePositionEndX;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        RayTouch();
        CarsFinished();
    }
    void RayTouch()
    {
        if (cantTouchTheCar)
        {
            if (alreadyClicked == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if (hitInfo.transform.gameObject.tag == "Car" || hitInfo.transform.gameObject.tag == "FirstCarTutorial" || hitInfo.transform.gameObject.tag == "CarRight")
                        {
                            var carScript = hitInfo.collider.GetComponent<Car>();
                            car = carScript;

                            mousePositionStartX = Input.mousePosition.x;
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (hitInfo.transform.gameObject.tag == "FirstCarTutorial" && firstCarTutorial)
                {
                    mousePositionEndX = Input.mousePosition.x;
                    if (mousePositionStartX > mousePositionEndX)
                    {
                        car.carCanDrive = true;
                        alreadyClicked = true;
                    }
                    else if (mousePositionStartX < mousePositionEndX)
                    {
                        car.carCanDriveBackward = true;
                        alreadyClicked = true;

                    }
                }
                else if (hitInfo.transform.gameObject.tag == "Car" && !firstCarTutorial)
                {
                    mousePositionEndX = Input.mousePosition.x;
                    if (mousePositionStartX > mousePositionEndX)
                    {
                        car.carCanDrive = true;
                        alreadyClicked = true;
                    }
                    else if (mousePositionStartX < mousePositionEndX)
                    {
                        car.carCanDriveBackward = true;
                        alreadyClicked = true;
                    }
                }
                else if (hitInfo.transform.gameObject.tag == "CarRight" && !firstCarTutorial)
                {
                    mousePositionEndX = Input.mousePosition.x;
                    if (mousePositionStartX < mousePositionEndX)
                    {
                        car.carCanDrive = true;
                        alreadyClicked = true;
                    }
                    else if (mousePositionStartX > mousePositionEndX)
                    {
                        car.carCanDriveBackward = true;
                        alreadyClicked = true;
                    }
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
            if (stopFinishTextSize)
            {
                canvasFinishGame.SetActive(true);
                finishText.fontSize++;
                if (finishText.fontSize > 50)
                {
                    stopFinishTextSize = false;
                }
            }
        }
    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene(0);
    }
}
