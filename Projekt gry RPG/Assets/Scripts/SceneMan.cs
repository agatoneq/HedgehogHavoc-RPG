using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;

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
        SceneManager.LoadScene(2);
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
        SceneManager.LoadScene(0);
    }
}