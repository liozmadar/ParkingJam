using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CarGoHomePath : MonoBehaviour
{
    public PathCreator myPathCreator;

    public float movement;

    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement += movementSpeed * Time.deltaTime;
        transform.position = myPathCreator.path.GetPointAtDistance(movement);
        transform.rotation = myPathCreator.path.GetRotationAtDistance(movement);
    }
}
