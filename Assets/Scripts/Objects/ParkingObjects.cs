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
            anim.SetTrigger("ParkingObjectHit");
        }
    }
}
