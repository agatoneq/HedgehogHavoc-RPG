using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{

Scene currentScene;
int sceneId;

    [SerializeField] private GameObject DeathPanel;

    public GameObject loadingPanel;
    public Slider loadingSlider;

    private PlayerStats playerStats;
    GameObject player;
    private Collider playerCollider;


    private bool PanelIsActive;

    private PauseMenu pauseMenu;

    void Start()
    {

         player = GameObject.Find("Capsule");
         playerCollider = player.GetComponent<Collider>();


       currentScene = SceneManager.GetActiveScene();
       sceneId = currentScene.buildIndex;
    
    playerStats = FindObjectOfType<PlayerStats>();

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

 playerStats.currentHealth = playerStats.MaxHealth;
        pauseMenu.Resume();
   
 playerStats.currentHealth = playerStats.MaxHealth;

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
