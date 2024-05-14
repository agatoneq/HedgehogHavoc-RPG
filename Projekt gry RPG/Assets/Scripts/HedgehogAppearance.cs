using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HedgehogClothes : MonoBehaviour
{
    public GameObject[] Items;
    private int currentItem = 0;

    // Start is called before the first frame update
    void Start()
    { 
        foreach(var item in Items)
        {
            item.SetActive(false);
        }
        if(currentItem < Items.Length)
            Items[currentItem].SetActive(true);
        
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
        Items[currentItem].SetActive(true);
    }
    public void OkButton()
    {
       // PlayerManager.instance.characterLook.Add(Items[currentItem]); //dodaj do aktualnie zalozonych rzeczy
        SceneManager.LoadScene("MainTown");
    }

    public void CancelButton()
    {
        //tu: zmiana sceny
    }
}
