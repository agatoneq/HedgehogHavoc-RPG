using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_GoodToBad : MonoBehaviour
{
    public bool EvilMode
    {
        get { return EvilMode; }
        set
        {
            HidingItems(value);
        }
    }
    public GameObject[] goodModeItems; //items that should be show only in good mode
    public GameObject[] evilModeItems; //items that should be show only in evil mode
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Evil", false);
        HidingItems(false); //shows items of good mode and hides items of evil mode
    }
    
    // Update is called once per frame
    void Update()
    {
    }
    void HidingItems(bool mode) //hide/shown items in case of mode
    {
        foreach (var item in goodModeItems)
        {
            item.SetActive(!mode);
        }

        foreach (var item in evilModeItems)
        {
            item.SetActive(mode);
        }
        animator.SetBool("Evil", mode);
    }
}
