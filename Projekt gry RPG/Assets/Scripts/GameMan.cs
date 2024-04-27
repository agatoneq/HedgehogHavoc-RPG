using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    [SerializeField] GameObject _mn;

    public void xyz()
    {
        _mn.SetActive(false);
    }

}
