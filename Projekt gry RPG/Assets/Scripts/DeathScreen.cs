using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    [SerializeField] private GameObject DeathPanel;

    public GameObject loadingPanel;
    public Slider loadingSlider;
    public int sceneId = 2;

    private bool PanelIsActive;

    private PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();

        if (pauseMenu != null)
        {
            Debug.Log("Znaleziono PauseMenu");
        }
        else
        {
            Debug.Log("Nie znaleziono PauseMenu");
        }
    }


    void Update()
    {
        if(DeathPanel.activeSelf)
        {
            Pause();
        }
    }

    void Pause()
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void RestartGame()
    {
        pauseMenu.Resume();
        StartCoroutine(LoadAsynchronously(sceneId));
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


}
