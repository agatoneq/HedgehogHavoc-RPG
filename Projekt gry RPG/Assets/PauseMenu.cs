using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

}
