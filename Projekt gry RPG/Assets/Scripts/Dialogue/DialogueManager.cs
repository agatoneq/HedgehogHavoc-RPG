using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

[Header("Dialogue UI")]
[SerializeField] private GameObject dialoguePanel;
[SerializeField] private TextMeshProUGUI dialogueText;

[Header("Choices UI")]
[SerializeField] private GameObject[] choices;
private TextMeshProUGUI[] choicesText;

private Story currentStory;

public bool dialogueIsPlaying {get; private set;}

private static DialogueManager instance;

    

    //_scr.enabled = true;

    private void Awake()
{
    if(instance != null)
    {
        Debug.LogWarning("więcej dialogów błąd");

    }
    instance = this;
}

public static DialogueManager GetInstance()
{
    return instance;
}

private void Start()
{
    dialogueIsPlaying = false;
    dialoguePanel.SetActive(false);

    //get all text for choices
choicesText = new TextMeshProUGUI[choices.Length];
int index = 0;
foreach (GameObject choice in choices)
{
choicesText[index]=choice.GetComponentInChildren<TextMeshProUGUI>();
index++;
}


}

private void Update()
{
    if(!dialogueIsPlaying)
    {
        return;
    }

    if(Input.GetKeyDown(KeyCode.Space))
    {

      ContinueStory();
    }
}

public void EnterDialogueMode(TextAsset inkJSON)
{
    currentStory = new Story(inkJSON.text);
    dialogueIsPlaying = true;
    dialoguePanel.SetActive(true);

ContinueStory();
}

private void ExitDialogueMode()
{
dialogueIsPlaying = false;
dialoguePanel.SetActive(false);
dialogueText.text = "";

}

private void ContinueStory()
{
        if(currentStory.canContinue)
    {
        dialogueText.text = currentStory.Continue();

        DispalyChoices();
    }
    else
    {
        ExitDialogueMode();
    }
}

private void DispalyChoices()
{
List<Choice> currentChoices = currentStory.currentChoices;

// sprawdzenie defensywne, aby upewnić się, że nasz UI może obsłużyć liczbę nadchodzących wyborów
if (currentChoices.Count > choices.Length)
{
    Debug.LogError("Podano więcej wyborów, niż UI może obsłużyć. Liczba podanych wyborów: "+ currentChoices.Count);
}

int index = 0;
// włącz i zainicjuj wybory do ilości wyborów dla tej linii dialogowej
foreach (Choice choice in currentChoices)
{
    choices[index].gameObject.SetActive(true);
    choicesText[index].text = choice.text;
    index++;
}
for (int i = index; i<choices.Length; i++)
{
    choices[i].gameObject.SetActive(false);
}

StartCoroutine(SelectFirstChoice());

}

private IEnumerator SelectFirstChoice()
{
    // System zdarzeń wymaga, aby najpierw go wyczyścić, a następnie poczekać
    // co najmniej jedną klatkę przed ustawieniem
    EventSystem.current.SetSelectedGameObject(null);
    yield return new WaitForEndOfFrame();
    EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
}

public void MakeChoice(int choiceIndex)
{
    currentStory.ChooseChoiceIndex(choiceIndex);
}

}
