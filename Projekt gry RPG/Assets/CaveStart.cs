using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Collections.Specialized;

public class CaveStart : MonoBehaviour
{
    private bool executed = false;
    private bool executed2 = false;
    private int x = 0;
    public GameObject Hedgehog;

    void Update()
    {
        if (!executed && SceneManager.GetActiveScene().name == "ztest")
        {
            Invoke("SetPositionAndRotation", 0.5f);
        }
    }

    void SetPositionAndRotation()
    {
        if (SceneManager.GetActiveScene().name == "ztest")
        {
            x += 1;
            if (x < 80)
            { 
            Hedgehog.transform.position = new Vector3(7.42f, -0.8f, 0.98f);
            Hedgehog.transform.rotation = Quaternion.Euler(0f, 95f, 0f);
        }

            Vector3 tp = Hedgehog.transform.position;
            UnityEngine.Debug.Log("Iteracja: " + x + "    Pozycja: " + tp);
            executed = true;
        }
    }
}
