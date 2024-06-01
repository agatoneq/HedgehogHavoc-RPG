using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class TeleportTownToCave : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingSlider;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadAsynchronously(3));
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

       // Hedgehog.transform.position = new Vector3(7.42f, -1.01f, 0.98f); ;
        //Hedgehog.transform.rotation = Quaternion.Euler(0f, 103.263f, 0f);

    }



}
