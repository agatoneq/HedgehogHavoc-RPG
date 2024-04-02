using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtPlayer : MonoBehaviour
{

public GameObject player;
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 currentPosition = transform.position;

        // Zignoruj różnicę wysokości między obiektem a graczem
        playerPosition.y = currentPosition.y;

        // Obróć obiekt, aby patrzył na gracza tylko na płaszczyźnie XZ
        transform.LookAt(playerPosition);
    }


}
