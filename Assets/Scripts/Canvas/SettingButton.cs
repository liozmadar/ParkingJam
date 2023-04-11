using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public GameObject toggleSettingButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleSettingButton()
    {
        if (toggleSettingButton.activeSelf == isActiveAndEnabled)
        {
            toggleSettingButton.SetActive(false);
        }
        else
        {
            toggleSettingButton.SetActive(true);
        }
    }
    public void GoToHomeScreenButton()
    {
        SceneManager.LoadScene(0);
    }
}
