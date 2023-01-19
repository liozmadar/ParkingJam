using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public GameObject gates;
    public float speed;

    private float stopGateGetDown = 0.5f;
    private float StopGateGetUp = 0.5f;

    private bool stopGateDown;
    private bool stopGateUp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stopGateDown)
        {
            stopGateGetDown -= Time.deltaTime;
            if (stopGateGetDown < 0)
            {
                stopGateDown = false;
                stopGateUp = true;
                stopGateGetDown = 0.5f;
            }
        }
        GateMoveDown();
        if (stopGateUp)
        {
            StopGateGetUp -= Time.deltaTime;
            if (StopGateGetUp < 0)
            {
                stopGateUp = false;
                StopGateGetUp = 0.5f;
            }
        }
        GateMoveUp();

    }
    void GateMoveDown()
    {
        if (stopGateDown)
        {
        gates.transform.position -= transform.up * speed * Time.deltaTime;
        }
    }
    void GateMoveUp()
    {
        if (stopGateUp)
        {
            gates.transform.position += transform.up * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car" || other.gameObject.tag == "FirstCarTutorial")
        {
            stopGateDown = true;
        }
    }
}
