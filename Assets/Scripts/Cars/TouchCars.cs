using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TouchCars : MonoBehaviour
{
    //The raycast 
    public RaycastHit hitInfo;
    //The Cars script
    public Car car;
    //Check if i already click on any car , so i cant move the other cars
    public bool alreadyClicked;
    //Cars speed
    public float speed;
    //Array of all the cars and finish line
    public GameObject[] carsFinished;
    public int howManyCarsFinished;
    public GameObject canvasFinishGame;
    public TextMeshProUGUI finishText;
    private bool stopFinishTextSize = true;
    //mouse input position
    private float x1;
    private float x2;

    public bool cantTouchTheCar = true;
    public bool firstCarTutorial = true;


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

                            x1 = Input.mousePosition.x;
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (hitInfo.transform.gameObject.tag == "FirstCarTutorial" && firstCarTutorial)
                {
                    x2 = Input.mousePosition.x;
                    if (x1 > x2)
                    {
                        car.carCanDrive = true;
                        alreadyClicked = true;
                    }
                    else if (x1 < x2)
                    {
                        car.carCanDriveBackward = true;
                        alreadyClicked = true;

                    }
                }
                else if (hitInfo.transform.gameObject.tag == "Car" && !firstCarTutorial)
                {
                    x2 = Input.mousePosition.x;
                    if (x1 > x2)
                    {
                        car.carCanDrive = true;
                        alreadyClicked = true;
                    }
                    else if (x1 < x2)
                    {
                        car.carCanDriveBackward = true;
                        alreadyClicked = true;
                    }
                }
                else if (hitInfo.transform.gameObject.tag == "CarRight" && !firstCarTutorial)
                {
                    x2 = Input.mousePosition.x;
                    if (x1 < x2)
                    {
                        car.carCanDrive = true;
                        alreadyClicked = true;
                    }
                    else if (x1 > x2)
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
        if (howManyCarsFinished == carsFinished.Length)
        {
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
