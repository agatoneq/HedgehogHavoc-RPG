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
    private KidnappedMole kidnappedMole;
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

        kidnappedMole = FindObjectOfType<KidnappedMole>();

        if (kidnappedMole != null)
        {
            Debug.Log("Znaleziono KidnappedMole");
        }
        else
        {
            Debug.Log("Nie znaleziono KidnappedMole");
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
        if (Player.Instance.quest.id == 19)
        {
            Debug.Log("Tak, to jst 19.");
            questGiver.finishQuest();
        }
        else
        {
            

            if (questGiver != null && questGiverId == 13)
            {
                if (kidnappedMole != null)
                {
                    kidnappedMole.enabled = true;
                }
            }

            if (Player.Instance.quest.id == 15)
            {
                questGiver.finishQuest();
            }

            if (questGiver != null && questGiverId != 12)
            {
                questGiver.setQuestActive(questGiverId);
            }
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
                if (Player.Instance.quest.id == 12 && questGiverId == 13)
                {
                        questGiver.finishQuest();
                }

            if (Player.Instance.quest.id == 13 && questGiverId == 14)
            {
                questGiver.finishQuest();
            }




            if (questGiverId == character.id && character.isAvailable == false)
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
                    Debug.Log($"Posta� z ID: {character.id} ju� istnieje w li�cie.");
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
