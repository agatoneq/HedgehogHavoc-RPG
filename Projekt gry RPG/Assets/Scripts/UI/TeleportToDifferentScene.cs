using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportToDifferentScene : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingSlider;
    public int sceneId = 0;

    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            UnityEngine.Debug.Log("audioManager jest nullem");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadAsynchronously(sceneId));
        }
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
