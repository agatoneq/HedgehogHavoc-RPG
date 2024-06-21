using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingSlider;

    private int previousSceneIndex;

    public void ClickPlayButton()
    {
        StartCoroutine(LoadAsynchronously(4));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingPanel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;

            yield return null;
        }
    }
    
    public void ClickContinueButton()
    {
        StartCoroutine(LoadAsynchronously(2));
    }

    public void ClickSettingsButton()
    {
        SceneManager.LoadScene("Settings");
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

    public void ClickMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClickOkInCharacterCreatorButton()
    {
        StartCoroutine(LoadAsynchronously(2));
    }
}