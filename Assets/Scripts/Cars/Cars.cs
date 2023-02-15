using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [Header("Get scripts components")]
    public RayManager rayManager;
    public Animator anim;

    [Header("Cars movement")]
    public bool carCanDrive;
    public bool carCanDriveBackward;
    public float speed;

    [Header("Check if the cars get hit from front/back")]
    private bool CarHitObjectFromFront;
    private bool CarHitObjectFromBack;

    [Header("Check the nearest RoadPath position")]
    public List<float> allPointsDistance;
    public int index;

    [Header("Road path points")]
    public float carPointsSpeed;
    public float angleSpeed = 10;
    public bool moveTheCar;

    [Header("Emotes")]
    public GameObject exclamation;
    private bool exclamationBool;
    private bool exclamationTheCollisionCar = true;
    private float exclamationTimer = 0.5f;

    [Header("Emotes images")]
    public SpriteRenderer SP;
    public Sprite emote1;
    public Sprite emote2;
    public Sprite emote3;
    //happy emotes
    public Sprite emote4;
    public Sprite emote5;
    public Sprite emote6;
    private bool makeHappyEmoteOnceBool;


    public GameObject mouseTutorial;

    // private bool noMoreCollision = true;

    // Start is called before the first frame update
    void Start()
    {
        rayManager = GameObject.Find("GameCarsManager").GetComponent<RayManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Push back from hits
        CarHitAnObjectFromFront();
        CarHitAnObjectFromBack();
        //Cars move forward/backword
        MoveCarsForward();
        MoveCarsBackword();
        //RoadPath
        FollowRoadPathPoints();
        //Emotes
        EmotesShow();
    }
    //Show emotes when get hit
    void EmotesShow()
    {
        //Sad emotes on get hit
        if (exclamationBool)
        {
            exclamation.SetActive(true);
            exclamationTimer -= Time.deltaTime;
            if (exclamationTimer < 0)
            {
                exclamationBool = false;
                exclamationTimer = 0.5f;
                exclamation.SetActive(false);
            }
        }
        //Happy emotes on finish
        if (makeHappyEmoteOnceBool)
        {
            exclamation.SetActive(true);
        }

        exclamation.transform.LookAt(Camera.main.transform.position);
    }

    //Push the cars back a little after they hit an object
    void CarHitAnObjectFromFront()
    {
        if (CarHitObjectFromFront)
        {
            rayManager.hitInfo.transform.position -= transform.forward * speed * Time.deltaTime;
        }
    }
    void CarHitAnObjectFromBack()
    {
        if (CarHitObjectFromBack)
        {
            rayManager.hitInfo.transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    void CarHitObjectFromFrontStop()
    {
        CarHitObjectFromFront = false;
    }
    void CarHitObjectFromBackStop()
    {
        CarHitObjectFromBack = false;
    }
    //Till here

    //Move the cars forward or backword
    void MoveCarsForward()
    {
        if (carCanDrive)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            exclamationTheCollisionCar = false;
        }
    }
    void MoveCarsBackword()
    {
        if (carCanDriveBackward)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            exclamationTheCollisionCar = false;
        }
    }
    //Till here

    //Trigger with the finish line and the gate of the finish line
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            rayManager.howManyCarsFinished++;
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Gate")
        {
            if (!makeHappyEmoteOnceBool)
            {
                HappyEmotesOnFinishCar();
                makeHappyEmoteOnceBool = true;
            }
        }
    }
    //Road Path Follow
    void FollowRoadPathPoints()
    {
        if (moveTheCar)
        {
            anim.enabled = false;
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
            anim.SetTrigger("GetHit");
            if (carCanDrive == true)
            {
                carCanDrive = false;
                CarHitObjectFromFront = true;
                Invoke("CarHitObjectFromFrontStop", 0.03f);
            }
            if (carCanDriveBackward == true)
            {
                carCanDriveBackward = false;
                CarHitObjectFromBack = true;
                Invoke("CarHitObjectFromBackStop", 0.03f);
            }

            //Emotes
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
            }
            //Till here
        }
    }

    //Happy emotes random chosen when car finish
    void HappyEmotesOnFinishCar()
    {
        Character.instance.anim.SetTrigger("CarPass");
        makeHappyEmoteOnceBool = true;
        float random = Random.Range(4, 7);
        if (random == 4)
        {
            SP.sprite = emote4;
        }
        if (random == 5)
        {
            SP.sprite = emote5;
        }
        if (random == 6)
        {
            SP.sprite = emote6;
        }
    }
}
