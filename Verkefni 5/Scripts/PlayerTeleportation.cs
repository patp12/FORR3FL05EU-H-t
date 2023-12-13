using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    // Function to teleport the player to the specified position
    public static void Teleport(Vector3 destination)
    {
        // Ensure there is a player in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Teleport the player to the destination
            player.transform.position = destination;
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }
}
