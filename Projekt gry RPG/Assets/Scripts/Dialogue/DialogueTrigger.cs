using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Player;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Text")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Quest Giver ID")]
    [SerializeField] public double questGiverId;

    public Character character;
    private QuestGiver questGiver;
    private bool playerInRange;
    private StarterAssets.FirstPersonController firstPersonController;
    private double currentQuest = Player.Instance.currentQuest;
    private List<Character> characters = Player.Instance.characters;
    

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

        if (questGiverId != null)
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
            if(questGiverId == character.id && character.isAvailable == false)
            {
                character.isAvailable = true;
                Debug.Log("Rozmawiasz z: " + character.name);
                bool characterExists = characters.Exists(c => c.id == character.id);

                if (!characterExists)
                {
                    characters.Add(character);
                }
                else
                {
                    Debug.Log($"Postaæ z ID: {character.id} ju¿ istnieje w liœcie.");
                }

                foreach (Character c in characters)
                {
                    Debug.Log($"ID: {c.id}, Name: {c.name}");
                }
            }

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
