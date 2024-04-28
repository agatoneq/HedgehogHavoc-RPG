using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public static bool IsMouseActive = false;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;
    public GameObject MainPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            if (IsMouseActive)
            {
                DeactivateMouse();
            }
            else
            {
                ActivateMouse();
            }

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

    void ActivateMouse()
    {
        IsMouseActive = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void DeactivateMouse()
    {
        IsMouseActive = false;
        Cursor.visible = false;
    }


    public void Resume()
    {
        SettingsMenuUI.SetActive(false);
        MainPanel.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        SettingsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        IsGamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void ShowSettings()
    {
        SettingsMenuUI.SetActive(true);
        MainPanel.SetActive(false);
    }

}
