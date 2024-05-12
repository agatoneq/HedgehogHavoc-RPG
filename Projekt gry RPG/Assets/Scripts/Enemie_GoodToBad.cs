using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_GoodToBad : MonoBehaviour
{
    public GameObject[] goodModeItems; //items that should be show only in good mode
    public GameObject[] evilModeItems; //items that should be show only in evil mode
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (animator != null)
        {
            animator.SetBool("Evil", false);
            HidingItems(false); //shows items of good mode and hides items of evil mode
        }
       else
            Debug.LogError("Animator is not assigned");
    }

    bool prevEvil = false;
    // Update is called once per frame
    void Update()
    {
        if (prevEvil != animator.GetBool("Evil"))
        {
            prevEvil = animator.GetBool("Evil");
            HidingItems(prevEvil);
        }
      
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
