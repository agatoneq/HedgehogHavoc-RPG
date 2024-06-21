using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidnappedMole : MonoBehaviour
{
    public GameObject kidnapper;
    public GameObject victim;

    void Start()
    {
        Vector3 victimPosition = victim.transform.position; //pozycja porwanego
        victimPosition.x -= 10;
        kidnapper.transform.position = victimPosition;
        kidnapper.SetActive(true);
    }

    float frames = 0;
    void Update()
    {
        
        if(frames < 20)
        {
            Vector3 kidnapperPosition = kidnapper.transform.position;
            kidnapperPosition.x += 0.1f;
            kidnapper.transform.position = kidnapperPosition;
            
        }
        if(frames >= 10 && frames < 20)
        {
            Vector3 victimPosition = victim.transform.position; //pozycja porwanego
            victimPosition.x += 0.1f;
            victim.transform.position = victimPosition;
        }
        if(frames >= 20)
        {
            victim.SetActive(false);
            kidnapper.SetActive(false);
        }
        frames+=0.1f;
    }
}
