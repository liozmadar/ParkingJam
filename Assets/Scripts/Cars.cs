using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    public bool carCanDrive;
    public bool carCanDriveBackward;

    public float speed;

    //get the scripts components
    [Header("Get scripts components")]
    public RayManager rayManager;

    [Header("Check the nearest RoadPath position")]
    public List<float> allPointsDistance;
   // public bool checkAllPointsDistanceBool;
    public int index;

    [Header("Road path points")]
    public float carPointsSpeed;
    public float angleSpeed = 10;
    public bool moveTheCar;

    // Start is called before the first frame update
    void Start()
    {
        rayManager = GameObject.Find("GameCarsManager").GetComponent<RayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCarsForward();
        MoveCarsBackword();

        FollowRoadPathPoints();
    }
    void MoveCarsForward()
    {
        if (carCanDrive)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    void MoveCarsBackword()
    {
        if (carCanDriveBackward)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
    }
    //Road Path Follow
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NavMeshRoad")
        {
            Debug.Log("wall road");
            carCanDrive = false;
            carCanDriveBackward = false;
         //   checkAllPointsDistanceBool = true;
            moveTheCar = true;

            //Check the distance between all road points
            for (int i = 0; i < RoadPathFollow.instance.roadPathPoints.Length; i++)
            {
                float dist = Vector3.Distance(RoadPathFollow.instance.roadPathPoints[i].transform.position, transform.position);
                allPointsDistance.Add(dist);
            }

            index = allPointsDistance.IndexOf(Mathf.Min(allPointsDistance.ToArray()));
            Debug.Log(index);
            //
        }
        if (other.gameObject.tag == "FinishLine")
        {
            rayManager.howManyCarsFinished++;
            gameObject.SetActive(false);
        }
    }

    void FollowRoadPathPoints()
    {
        if (moveTheCar)
        {
            if (index < RoadPathFollow.instance.roadPathPoints.Length)
            {
                transform.position = Vector3.MoveTowards(transform.position, RoadPathFollow.instance.roadPathPoints[index].transform.position, carPointsSpeed);
                //   transform.LookAt(RoadPathFollow.instance.roadPathPoints[middleCarCollision.index].transform.position);

                if (Vector3.Distance(transform.position, RoadPathFollow.instance.roadPathPoints[index].transform.position) <= 0.1f)
                {
                    index++;
                }

                var targetRotation = Quaternion.LookRotation(RoadPathFollow.instance.roadPathPoints[index].transform.position - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angleSpeed * Time.deltaTime);
            }
        }
    }
    //Till here




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "CarRight" || collision.gameObject.tag == "FirstCarTutorial" || collision.gameObject.tag == "ParkingObjects")
        {
            if (carCanDrive == true)
            {
                carCanDrive = false;
            }
            if (carCanDriveBackward == true)
            {
                carCanDriveBackward = false;
            }





            /*if (carCanDrive == true)
            {
                carCanDrive = false;
                CarHitObjectFromFront = true;
                touchCars.cantTouchTheCar = true;
                Invoke("CarHitObjectFromFrontStop", 0.03f);
                carhitSparkFront.Play(true);
            }
            else if (carCanDriveBackward == true)
            {
                carCanDriveBackward = false;
                CarHitObjectFromBack = true;
                touchCars.cantTouchTheCar = true;
                Invoke("CarHitObjectFromBackStop", 0.03f);
                carhitSparkBack.Play(true);
            }
            touchCars.alreadyClicked = false;
            anim.SetTrigger("GetHit");
            if (exclamationTheCollisionCar)
            {
                exclamationBool = true;
                float random = Random.Range(1, 4);
                if (random == 1)
                {
                    SP.sprite = emote1;
                }
                if (random == 2)
                {
                    SP.sprite = emote2;
                }
                if (random == 3)
                {
                    SP.sprite = emote3;
                }
            }
            else if (!exclamationTheCollisionCar)
            {
                exclamationTheCollisionCar = true;
            }*/
        }
    }
}
