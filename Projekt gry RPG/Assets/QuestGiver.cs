using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using StarterAssets;

public class QuestGiver : MonoBehaviour
{
    private bool executed = false;
    private int x = 0;

    public Quest quest;
    public GameObject player;
    //public Assets.Scripts.Player.Player hedgehogPlayer;
    public GameObject newQuestPanel;
    public TMP_Text ContentText;
    StarterAssets.FirstPersonController _scr;

    void Start()
    {
        _scr = gameObject.GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (!executed && SceneManager.GetActiveScene().name == "MainTown")
        {
            ShowPanel();
            Invoke("HidePanel", 5f);
        }
    }

    void ShowPanel()
    {
        if (SceneManager.GetActiveScene().name == "MainTown")
        {
            setQuestActive();
            executed = true;
        }
    }

    void HidePanel()
    {
        newQuestPanel.SetActive(false);
    }

    public void setQuestActive()
    {
        quest.isActive = true;
        newQuestPanel.SetActive(true);
        ContentText.text = quest.newQuestInfo;
    }

    public void setQuest0NotActive()
    {
        quest.isActive = false;
    }
}
