using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject backGroundUI;

    public TextMeshProUGUI levelText;
    public int levelTextInt;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        levelTextInt = RayManager.instance.sceneLevel + 1;
        levelText.text = "Level - " + levelTextInt;
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
        SceneManager.LoadScene(RayManager.instance.sceneLevel);
    }
}
