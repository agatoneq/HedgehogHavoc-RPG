using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Text")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Quest Giver ID")]
    [SerializeField] private int questGiverId; // Unikalny identyfikator dla parowania z QuestGiver

    private QuestGiver questGiver;
    private bool playerInRange;

    private static DialogueTrigger activeDialogueTrigger; // Statyczna zmienna śledząca aktywny DialogueTrigger

    void Start()
    {
        QuestGiver[] allQuestGivers = FindObjectsOfType<QuestGiver>();
        foreach (QuestGiver qg in allQuestGivers)
        {
            if (qg.questGiverId == questGiverId)
            {
                questGiver = qg;
                break;
            }
        }

        if (questGiver != null)
        {
            Debug.Log("Znaleziono QuestGiver z ID: " + questGiverId);
        }
        else
        {
            Debug.Log("Nie znaleziono QuestGiver z ID: " + questGiverId);
        }

        DialogueManager.GetInstance().OnDialogueEnd += OnDialogueEnd;
    }

    private void OnDestroy()
    {
        if (DialogueManager.GetInstance() != null)
        {
            DialogueManager.GetInstance().OnDialogueEnd -= OnDialogueEnd;
        }
    }

    private void OnDialogueEnd()
    {
        if (questGiver != null)
        {
            questGiver.setQuestActive(questGiverId);
        }
        
        visualCue.SetActive(false);
        activeDialogueTrigger = null; // Resetujemy aktywny DialogueTrigger po zakończeniu dialogu

        // Dezaktywacja skryptu o questGiverId równym 0
        if (questGiverId == 0)
        {
            this.enabled = false;
        }
    }

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        // Sprawdzenie, czy ten DialogueTrigger jest aktywny
        if (activeDialogueTrigger != null && activeDialogueTrigger != this)
        {
            visualCue.SetActive(false);
            return;
        }

        if (questGiverId==0)
        {
            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                visualCue.SetActive(true);
                Debug.Log("TAK TO 0");
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                activeDialogueTrigger = this; // Ustawiamy aktywny DialogueTrigger
            }
            else if (!DialogueManager.GetInstance().dialogueIsPlaying)
            {
                visualCue.SetActive(false);
             
            }
        }
        else
        {
            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                visualCue.SetActive(true);
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log("to nie jest 0");
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    activeDialogueTrigger = this; // Ustawiamy aktywny DialogueTrigger
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            if (activeDialogueTrigger == this)
            {
                activeDialogueTrigger = null; // Resetujemy aktywny DialogueTrigger po wyjściu z zasięgu
            }
        }
    }
}
