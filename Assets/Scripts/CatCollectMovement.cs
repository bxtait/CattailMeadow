using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollectMovement : MonoBehaviour
{
    public GameObject player; // Assign the player game object to this variable in the inspector

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}

