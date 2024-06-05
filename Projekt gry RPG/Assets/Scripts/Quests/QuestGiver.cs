using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class QuestGiver : MonoBehaviour
{
    public int questGiverId;

    private bool executed = false;
    private int x = 0;

    public Quest quest;
    public GameObject player;
    public GameObject newQuestPanel;
    public TMP_Text TitleText;
    public TMP_Text ContentText;

    void ShowPanel()
    {
        newQuestPanel.SetActive(true);
    }

    void HidePanel()
    {
        newQuestPanel.SetActive(false);
    }

    private IEnumerator ActivatePanelWithDelay()
    {
        ShowPanel();
        yield return new WaitForSeconds(6f);
        HidePanel();
    }

    public void setQuestActive(int id)
    {
        Debug.Log("Aktywowano zadanie: " + quest.newQuestInfo);
        quest.isActive = true;
        TitleText.text = "Nowe zadanie!";
        ContentText.text = quest.newQuestInfo;
        StartCoroutine(ActivatePanelWithDelay());
    }

    public void finishQuest()
    {
        x++;
        Debug.Log("Ukoñczono zadanie: " + quest.newQuestInfo);
        quest.isActive = false;
        TitleText.text = "Gratulacje!";
        ContentText.text = "Ukoñczy³eœ zadanie: " + quest.title + "!";
        StartCoroutine(ActivatePanelWithDelay());

        // Aktywacja skryptu DialogueTrigger o wartoœci questGiverId równej x
        ActivateDialogueTrigger(x);
    }

    private void ActivateDialogueTrigger(int id)
    {
        DialogueTrigger[] allTriggers = FindObjectsOfType<DialogueTrigger>();
        foreach (DialogueTrigger trigger in allTriggers)
        {
            if (trigger.questGiverId == id)
            {
                trigger.enabled = true; // Aktywowanie skryptu
                Debug.Log("Aktywowano DialogueTrigger z ID: " + id);
            }
        }
    }
}