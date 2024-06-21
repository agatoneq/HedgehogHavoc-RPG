using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
using Assets.Scripts.Player;

public class QuestGiver : MonoBehaviour
{
    public float questGiverId;

    private bool executed = false;
    private double x = 0.0;

    public Quest quest;
    public GameObject player;
    public GameObject newQuestPanel;
    public TMP_Text TitleText;
    public TMP_Text ContentText;
    public TMP_Text BookTitleText;
    public TMP_Text BookContentText;

    public GameObject wall;
    public GameObject remy;

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

    public void setQuestActive(double id)
    {
        Debug.Log("Aktywowano zadanie: " + quest.newQuestInfo);
        Debug.Log(" zadanie z player: " + Player.Instance.currentQuest);
        Player.Instance.currentQuest = id;
        Debug.Log(" zadanie z player po przypisaniu: " + Player.Instance.currentQuest);
        quest.isActive = true;
        TitleText.text = "Nowe zadanie!";
        ContentText.text = quest.newQuestInfo;
        BookTitleText.text = quest.title;
        BookContentText.text = quest.description;
        StartCoroutine(ActivatePanelWithDelay());
    }

    public void finishQuest()
    {
        Debug.Log(" zadanie z player sie konczy: " + Player.Instance.currentQuest);
        x++;
        Debug.Log("Ukoñczono zadanie: " + quest.newQuestInfo);
        quest.isActive = false;
        TitleText.text = "Gratulacje!";
        ContentText.text = "Ukoñczy³eœ zadanie: " + quest.title + "!";
        BookTitleText.text = "ZnajdŸ zadanie";
        switch(Player.Instance.currentQuest)
        {
            case 0:
                BookContentText.text = "Nie masz obecnie ¿adnych aktywnych zadañ. Spróbuj porozmawiaæ z Krow¹ Wies³aw¹.";
                ActivateDialogueTrigger(10);
                break;
            case 11:
                quest = new Quest("Œladem krecich korytarzy", "Có¿… to chyba nie by³a osoba, która chcia³a dla Ciebie dobrze. Oby nastêpnym razem by³o lepiej. Eksploruj dalej jaskiniê i odnajdŸ prawdziwego sojusznika.", "OdnajdŸ kreciego in¿yniera", 0, 0);
                setQuestActive(12);
                ActivateDialogueTrigger(13);
                wall.SetActive(false);
                Vector3 remyPosition = remy.transform.position;
                remyPosition.y = -5;
                break;
            case 12:
                ActivateDialogueTrigger(14);
                break;
            case 13:
                wall.SetActive(true);
                remy.SetActive(false);
                break;
            case 14:
                quest = new Quest("Wybawiciel", "Bat Wuhan przerwa³ Bogdanowi w momencie, gdy ten chcia³ przekazaæ Ci wa¿ne informacje. Teraz, gdy nietoperz zosta³ pokonany, musisz porozmawiaæ z Bogdanem i dowiedzieæ siê, co wa¿nego chcia³ Ci powiedzieæ.", "Porozmawiaj z Bogdanem", 0, 0);
                setQuestActive(15);
                ActivateDialogueTrigger(16);
                break;
            case 18:
                BookContentText.text = "Nie masz obecnie ¿adnych aktywnych zadañ. Spróbuj porozmawiaæ z Mam¹ Owc¹.";
                break; 
            case 28:
                BookContentText.text = "Nie masz obecnie ¿adnych aktywnych zadañ. Spróbuj porozmawiaæ z Kameleonem Zakonnikiem.";
                break;
            default:
                BookContentText.text = "Nie masz obecnie ¿adnych aktywnych zadañ. Spróbuj porozmawiaæ z innym mieszkañcem.";
                break;
        }

        StartCoroutine(ActivatePanelWithDelay());

        // Aktywacja skryptu DialogueTrigger o wartoœci questGiverId równej x
        
    }

    private void ActivateDialogueTrigger(double id)
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