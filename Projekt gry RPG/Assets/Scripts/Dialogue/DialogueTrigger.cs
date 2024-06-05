using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Text")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Quest Giver ID")]
    [SerializeField] public int questGiverId;

    private QuestGiver questGiver;
    private bool playerInRange;
    private StarterAssets.FirstPersonController firstPersonController;

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

        // Znalezienie FirstPersonController
        firstPersonController = FindObjectOfType<StarterAssets.FirstPersonController>();

        if (firstPersonController != null)
        {
            Debug.Log("Znaleziono FirstPersonController");
        }
        else
        {
            Debug.Log("Nie znaleziono FirstPersonController");
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

        if (questGiverId == 0)
        {
            this.enabled = false;
        }

        if (firstPersonController != null)
        {
            firstPersonController.enabled = true;
        }
    }

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            if (firstPersonController != null)
            {
                firstPersonController.enabled = false;
            }

        }
        else if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(false);
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
        }
    }
}
