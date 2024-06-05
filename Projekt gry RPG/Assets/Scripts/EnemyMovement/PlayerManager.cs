using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    public GameObject player;


    private void Awake()
    {
       instance = this;
        player = GameObject.Find("PlayerCapsule");
    }
    #endregion
    /**
     * 0 - uszy 
     * 1 - oczy
     * 2 - pyszczek
     * 3 - rêce
     * 4 - akcesoria
     */
    public static string[] characterLook = new string[5]; //aktualnie zalozone rzeczy/ubrania
    public static bool armor = false; //czy ma zbroje
}
