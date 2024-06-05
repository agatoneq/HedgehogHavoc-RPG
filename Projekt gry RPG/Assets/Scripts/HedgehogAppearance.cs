using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HedgehogClothes : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject Armor_helmet;
    public GameObject Armor_breastplate;
    private int currentItem = 0;
    public int nrTab;

    // Start is called before the first frame update
    void Start()
    {
        if (Items.Length != 0) //jesli Jezy jest w kreatorze
        {
            foreach (var item in Items)
            {
                item.SetActive(false);
            }
            if (currentItem < Items.Length)
            {
                Items[currentItem].SetActive(true);
                PlayerManager.characterLook[nrTab] = Items[currentItem].name;
                Debug.Log("Apperence: Start() -> kreator: set active: " + Items[currentItem].name + "\n");
                
            }
        }
        else if(this.gameObject.scene.name != "CharacterCreator") //jesli Jezy jest na scenie
        {
            Debug.Log("Apperance: Start() -> na scenie, ilosc w liscie: "+ PlayerManager.characterLook.Length);
            foreach (var c in PlayerManager.characterLook)
            {
                Transform obj = transform.Find(c);
                if (obj != null)
                {
                    GameObject gameObj = obj.gameObject;
                    gameObj.SetActive(true);
                }
            }
            if (PlayerManager.armor && Armor_breastplate != null & Armor_helmet != null)
            {
                Armor_helmet.SetActive(true);
                Armor_breastplate.SetActive(true);
            }
        }

    }
    public void Change(bool next) //next: true -> przycisk w przod, false -> w tyl
    {
        Items[currentItem].SetActive(false);
        if (next)
        {
            if (currentItem < Items.Length - 1)
                currentItem++;
            else
                currentItem = 0; //zapetlenie pokazywanych itemow
        }
        else
        {
            if (currentItem > 0)
                currentItem--;
            else
                currentItem = Items.Length - 1;
        }
        PlayerManager.characterLook[nrTab] = Items[currentItem].name;  //tablica z wybranymi elementami
        
        Items[currentItem].SetActive(true); //pokazanie wybranego itemku
    }
    public void OkButton()
    {
        SceneManager.LoadScene("MainTown");
    }

    public void CancelButton()
    {
        
    }
}
