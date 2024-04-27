using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class SceneMan : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;

    private int previousSceneIndex;



    public void ClickPlayButton()
    {
        StartCoroutine(LoadAsynchronously(2));

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;

            yield return null;
        }
    }
    
    public void ClickContinueButton()
    {
        SceneManager.LoadScene(3);
    }

    public void ClickSettingsButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickQuitButton()
    {
        Application.Quit();
    }

    public void ClickGoBackButton()
    {
        UnityEngine.Debug.Log(previousSceneIndex);
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void ClickPauseButton()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        UnityEngine.Debug.Log(previousSceneIndex);
        Time.timeScale = 0;
        SceneManager.LoadScene(4);
    }

    public void ClickMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}