using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;


    private void Awake()
    {
       instance = this;
    }
    #endregion

    public GameObject player;
    
    /**
     * 0 - uszy 
     * 1 - oczy
     * 2 - pyszczek
     * 3 - rêce
     * 4 - akcesoria
     */
    public static GameObject[] characterLook = new GameObject[5]; //aktualnie zalozone rzeczy/ubrania
}
