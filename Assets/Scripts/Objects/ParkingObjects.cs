using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingObjects : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


        

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "CarRight" || collision.gameObject.tag == "FirstCarTutorial")
        {
           // anim.SetTrigger("ParkingObjectHit");

            if (transform.eulerAngles.y > 80 && transform.eulerAngles.y < 100)
            {
                Debug.Log("1", gameObject);
                anim.SetTrigger("ParkingObjectUp");
            }
            else if (transform.eulerAngles.y > 170 && transform.eulerAngles.y < 190)
            {
                Debug.Log("2", gameObject);
                anim.SetTrigger("ParkingObjectRight");
            }
            else if (transform.eulerAngles.y > 260 && transform.eulerAngles.y < 280)
            {
                Debug.Log("3", gameObject);
                anim.SetTrigger("ParkingObjectDown");
            }
            else if (transform.eulerAngles.y < 10 || transform.eulerAngles.y > 350)
            {
                Debug.Log("4", gameObject);
                anim.SetTrigger("ParkingObjectLeft");
            }
        }
    }
}
