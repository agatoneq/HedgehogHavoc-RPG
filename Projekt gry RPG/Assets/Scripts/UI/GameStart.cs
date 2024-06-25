using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Player;

public class GameStart : MonoBehaviour
{
    private bool executed = false;
    private int x = 0;
    public QuestGiver questGiver;

    void Start()
    {
        QuestGiver[] allQuestGivers = FindObjectsOfType<QuestGiver>();
        foreach (QuestGiver qg in allQuestGivers)
        {
            questGiver = qg;
            break;
        }

        if (questGiver != null)
        {
            Debug.Log("Znaleziono QuestGiver z ID: 11");
        }
        else
        {
            Debug.Log("Nie znaleziono QuestGiver z ID: 11");
        }

        switch (Player.Instance.quest.id)
        {
            case 0:
                questGiver.ActivateDialogueTrigger(0);
                break;
            case 10:
                questGiver.ActivateDialogueTrigger(11);
                break;
            case 19:
                questGiver.ActivateDialogueTrigger(19);
                break;
            case 19.5:
                questGiver.ActivateDialogueTrigger(20);
                break;
        }
    }
/*    void Update()
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
            questGiver.setQuestActive();
            executed = true;
        }
    }*/
}
