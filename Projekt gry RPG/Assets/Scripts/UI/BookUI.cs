using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Player;

public class BookUI : MonoBehaviour
{
    private List<Character> characters = Player.Instance.characters;

    public GameObject panel;
    public TMP_Text TitleText;
    public TMP_Text ContentText;
    public Image image;

    void Start()
    {
        Debug.Log("Book ui start");

        foreach (Character character in characters)
        {
            Debug.Log($"ID: {character.id}, Name: {character.name}       ");
        }

        /*        inventory.onInventoryChanged += UpdateUI;
                slots = itemsParent.GetComponentsInChildren<InventorySlot>().ToList();
                Debug.Log("slot count" + slots.Count);*/
    }

    public void showCharacterInBook()
    {
/*        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.Items.Count)
            {
                slots[i]?.AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i]?.ClearSlot();
            }
        }*/

    }
}