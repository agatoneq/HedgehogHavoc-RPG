using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class TownReturn : MonoBehaviour
{
    void Awake()
    {
        UnityEngine.Debug.Log("Poprzednia scena: " + SceneTracker.previousScene);
    }
}
