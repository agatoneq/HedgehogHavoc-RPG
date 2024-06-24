using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class TeleportToTown : MonoBehaviour
{
    private bool wasInDifferentScene = false;
    public GameObject loadingPanel;
    public Slider loadingSlider;
    // public GameObject Hedgehog;


    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if(audioManager == null)
        {
            UnityEngine.Debug.Log("audioManager jest nullem");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadAsynchronously(2));
        audioManager.PlaySFX(audioManager.playerTeleported);
        //Hedgehog.transform.position = new Vector3(507f, 5.1897f, 229.61f);

        // Ustawia rotacjê gracza na (0, -3.4, 0)
       // Hedgehog.transform.rotation = Quaternion.Euler(0f, -3.4f, 0f);

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
