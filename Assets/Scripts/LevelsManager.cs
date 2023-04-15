using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;

    private int levelNumber;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        levelNumber = RayManager.instance.sceneLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadLevel()
    {
        if (!CanvasManager.instance.enablePlayButton)
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
}
