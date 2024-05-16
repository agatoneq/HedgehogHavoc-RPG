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

    private bool PanelIsActive;
    // Start is called before the first frame update

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
        StartCoroutine(LoadAsynchronously(2));
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
