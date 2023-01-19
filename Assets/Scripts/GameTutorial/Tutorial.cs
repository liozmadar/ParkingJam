using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Sprite clickedMouse;
    public Sprite UnClickedMouse;

    private Vector3 FirstMouseSpritePos;
    public float speed;
    //hand finger tutorial movment
    private bool stopMouse = true;
    private float timer1 = 1;
    private float timer2 = 2;
    private float timer3 = 3;

    // Start is called before the first frame update
    void Start()
    {
        FirstMouseSpritePos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MouseTutorial();
    }
    void MouseTutorial()
    {
        timer1 -= Time.deltaTime;
        if (timer1 < 0 && stopMouse)
        {
            MouseSpriteMove();
        }
        timer2 -= Time.deltaTime;
        if (timer2 < 0)
        {
            stopMouse = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = UnClickedMouse;
        }
        timer3 -= Time.deltaTime;
        if (timer3 < 0)
        {
            RepeatToMouseSpriteMove();
        }
    }
    void MouseSpriteMove()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = clickedMouse;
        gameObject.transform.position -= transform.right * speed * Time.deltaTime;
        gameObject.transform.position += transform.up * speed * Time.deltaTime;
    }
    void RepeatToMouseSpriteMove()
    {
        gameObject.transform.position = FirstMouseSpritePos;
        timer1 = 1;
        timer2 = 2;
        timer3 = 3;
        stopMouse = true;
    }
}
