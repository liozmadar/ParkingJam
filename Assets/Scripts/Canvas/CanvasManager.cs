using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject backGroundUI;

    public TextMeshProUGUI levelText;
    public int levelTextInt;

    public GameObject resetButton;

    public GameObject playButton;
    public bool enablePlayButton;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        levelTextInt = RayManager.instance.sceneLevel;
        levelText.text = "Level - " + levelTextInt;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleBackGroundUI();

        if (levelTextInt + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            GetThePlayButtonComponent();
        }
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
        if (!enablePlayButton)
        {
            RayManager.instance.FinishTheStageBool = false;
            backGroundUI.SetActive(false);
            SceneManager.LoadScene(RayManager.instance.sceneLevel);
        }
    }
    public void ToggleResetButton()
    {
        if (resetButton.activeSelf == isActiveAndEnabled)
        {
            resetButton.SetActive(false);
        }
        else
        {
            resetButton.SetActive(true);
        }
    }
    public void ResetLevelsCountButton()
    {
        PlayerPrefs.DeleteKey("sceneLevel");
        SceneManager.LoadScene(0);
    }
    private void GetThePlayButtonComponent()
    {
        playButton = GameObject.Find("PlayButtonText");
        if (playButton == isActiveAndEnabled)
        {
            playButton.GetComponent<TextMeshProUGUI>().text = "New Levels coming soon!";
            enablePlayButton = true;
        }
    }
}
