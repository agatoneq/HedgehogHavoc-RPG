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

    private bool hasFoundCowsScythe = false;

    void Start()
    {
        Screen.fullScreen = true;

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

        double piqID = Player.Instance.quest.id;

        Debug.Log("Twoje obecne zadanie to:" + piqID);

        if (piqID == 0 || piqID == -1)
        {
            questGiver.ActivateDialogueTrigger(0);
        }
        else if (piqID >= 10 && piqID <= 18)
        {
            questGiver.ActivateDialogueTrigger(11);
        }
        else if (piqID == 19)
        {
            if (Player.Instance.Inventory.HasItem("Cow's Scythe"))
            {
                questGiver.ActivateDialogueTrigger(19);
            }
        }
        else if (piqID == 19.5)
        {
            questGiver.ActivateDialogueTrigger(20);
        }
    }


    void Update()
    {
        if (!hasFoundCowsScythe)
        {
            CheckForCowsScythe();
        }
    }

    public void CheckForCowsScythe()
    {
        if (Player.Instance.Inventory.HasItem("Cow's Scythe"))
        {
            Debug.Log("Je¿ ma kosê");
            questGiver.ActivateDialogueTrigger(19);
            //DisableQuestGiverWithId(10);
            hasFoundCowsScythe = true; // Ustaw flagê na true, aby przestaæ sprawdzaæ
        }
    }

/*    private void DisableQuestGiverWithId(int questGiverId)
    {
        QuestGiver[] allQuestGivers = FindObjectsOfType<QuestGiver>();
        foreach (QuestGiver qg in allQuestGivers)
        {
            if (qg.questGiverId == questGiverId)
            {
                qg.enabled = false;
                Debug.Log("QuestGiver with ID " + questGiverId + " has been disabled.");
                break;
            }
        }
    }*/
}
