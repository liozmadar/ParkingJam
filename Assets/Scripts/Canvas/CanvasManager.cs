using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject backGroundUI;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleBackGroundUI();
    }
    void ToggleBackGroundUI()
    {
        if (RayManager.instance.FinishTheStageBool)
        {
            backGroundUI.SetActive(true);
        }
    }
    public void ClickOnPlayButton()
    {
        RayManager.instance.FinishTheStageBool = false;
        backGroundUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
