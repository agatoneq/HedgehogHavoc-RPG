using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public void ClickPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ClickContinueButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickSettingsButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickQuitButton()
    {
        Application.Quit();
    }
}