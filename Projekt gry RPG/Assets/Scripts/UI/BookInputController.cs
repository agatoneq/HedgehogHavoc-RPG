using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Player;

public class BookInputController : MonoBehaviour
{

    public void onMouseEnter()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

    }

    public void onMouseExit()
    {
       // Cursor.visible = false;
    }

    public GameObject BookPanel;
    public GameObject QuestsPanel;
    public GameObject CharactersPanel;
    public static bool IsBookOpened = false;
    public static bool IsQPOpened = true;
    public static bool IsChPOpened = false;
    public static bool IsMouseActive = false;

    private int currentCharacter = 0;

    public TMP_Text TitleText;
    public TMP_Text ContentText;
    public Image image;
    //public GameObject pref;

    private List<Character> characters = Player.Instance.characters;

    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.Log("audioManager jest nullem");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            if (IsBookOpened)
            {
                CloseBook();
            }
            else
            {
                OpenBook();
            }

        if (Input.GetKeyDown(KeyCode.Escape))
            if (IsBookOpened)
            {
                CloseBook();
            }
    }


    public void CloseBook()
    {
        BookPanel.SetActive(false);
        IsBookOpened = false;
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenBook()
    {
        BookPanel.SetActive(true);
        IsBookOpened = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioManager.PlaySFX(audioManager.openedBook);
    }

    public void ShowQuestsPanel()
    {
        CharactersPanel.SetActive(false);
        QuestsPanel.SetActive(true);
        IsQPOpened = true;
        IsChPOpened = false;
    }

    public void ShowCharactersPanel()
    {
        CharactersPanel.SetActive(true);
        QuestsPanel.SetActive(false);
        IsQPOpened = false;
        IsChPOpened = true;
    }

    public void ChangeCharacterPanel(bool next)
    {
        if (next)
        {
            Debug.Log($"next: {currentCharacter}, count listy: {characters.Count}");

            
            if (currentCharacter < characters.Count-1)
            {
                currentCharacter++;

                Debug.Log($"next w if: {currentCharacter}, count listy: {characters.Count}");

                Character character = characters[currentCharacter];

                TitleText.text = character.name;
                ContentText.text = character.description;
                //pref = character.pref;
                image.sprite = character.image;
            }

        }
        else
        {
            Debug.Log($"pre: {currentCharacter}, count listy: {characters.Count}");


            if (currentCharacter > 0)
            {
                currentCharacter--;

                Debug.Log($"pre w if: {currentCharacter}, count listy: {characters.Count}");

                Character character = characters[currentCharacter];

                TitleText.text = character.name;
                ContentText.text = character.description;
                //pref = character.pref;
                image.sprite = character.image;
            }
        }
    }
}
