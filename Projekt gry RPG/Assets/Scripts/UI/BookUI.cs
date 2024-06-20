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
    public Character character;
    private List<Character> characters = Player.Instance.characters;
   
       
    public GameObject panel;


        void Start()
        {
            Debug.Log("Book ui start");

        bool characterExists = characters.Exists(c => c.id == character.id);

        if (!characterExists)
        {
            characters.Add(character);
        }
        else
        {
            Debug.Log($"Postaæ z ID: {character.id} ju¿ istnieje w liœcie.");
        }

        // Logowanie wszystkich postaci w liœcie
        foreach (Character c in characters)
        {
            Debug.Log($"ID: {c.id}, Name: {c.name}");
        }




        /*            foreach (Character character in characters)
                    {
                        Debug.Log($"boookuiii ID: {character.id}, Name: {character.name}       ");
                    }*/

        /*            foreach (GameObject panell in charactersPanels)
                    {
                        Debug.Log($" namee: {TitleText.text}, desc: {ContentText.text}");
                    }*/

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