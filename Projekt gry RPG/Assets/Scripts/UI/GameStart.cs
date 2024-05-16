using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject QuestPanel;
    private bool executed = false;
    private int x = 0;

    void Update()
    {
        if (!executed && SceneManager.GetActiveScene().name == "MainTown")
        {
            Invoke("ShowPanel", 5f);
        }
    }

    void ShowPanel()
    {
        if (SceneManager.GetActiveScene().name == "MainTown")
        {
            QuestPanel.SetActive(false);
            executed = true;
        }
    }
}
