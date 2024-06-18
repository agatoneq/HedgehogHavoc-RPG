using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookInputController : MonoBehaviour
{

    public void onMouseEnter()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

    }

    public void onMouseExit()
    {
       // Cursor.visible = false;
    }

    public GameObject BookPanel;
    public GameObject QuestsPanel;
    public GameObject CharactersPanel;
    public static bool IsBookOpened = false;
    public static bool IsQPOpened = true;
    public static bool IsChPOpened = false;
    public static bool IsMouseActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            if (IsBookOpened)
            {
                CloseBook();
            }
            else
            {
                OpenBook();
            }

        if (Input.GetKeyDown(KeyCode.Escape))
            if (IsBookOpened)
            {
                CloseBook();
            }
    }


    public void CloseBook()
    {
        BookPanel.SetActive(false);
        IsBookOpened = false;
        Cursor.visible = false;
    }

    public void OpenBook()
    {
        BookPanel.SetActive(true);
        IsBookOpened = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void ShowQuestsPanel()
    {
        CharactersPanel.SetActive(false);
        QuestsPanel.SetActive(true);
        IsQPOpened = true;
        IsChPOpened = false;
    }

    public void ShowCharactersPanel()
    {
        CharactersPanel.SetActive(true);
        QuestsPanel.SetActive(false);
        IsQPOpened = false;
        IsChPOpened = true;
    }
}
