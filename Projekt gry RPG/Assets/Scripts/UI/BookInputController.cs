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
    public static bool IsBookOpened = false;
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
}
