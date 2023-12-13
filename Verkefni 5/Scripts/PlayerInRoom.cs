using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private bool isInRoom = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomEntrance"))
        {
            // Player entered the room
            isInRoom = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RoomEntrance"))
        {
            // Player exited the room
            isInRoom = false;
        }
    }

    // Add logic in your script based on the value of isInRoom
}
