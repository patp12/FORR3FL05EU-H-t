using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoiseController : MonoBehaviour
{
    public AudioClip outsideAmbientNoise;
    public AudioClip insideAmbientNoise;

    private bool isInRoom = false;
    private AudioSource audioSource;  // Reference to the AudioSource component

    void Start()
    {
        // Get or add the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the initial ambient noise
        UpdateAmbientNoise();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the room.");
            // Player entered the room
            isInRoom = true;
            UpdateAmbientNoise();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the room.");
            // Player exited the room
            isInRoom = false;
            UpdateAmbientNoise();
        }
    }

    // Add a method to update the ambient noise based on the player's location
    void UpdateAmbientNoise()
    {
        Debug.Log("UpdateAmbientNoise called. isInRoom: " + isInRoom);

        // Play or stop the audio source based on whether the player is in the room
        if (isInRoom)
        {
            // Play the inside ambient noise
            audioSource.clip = insideAmbientNoise;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Play the outside ambient noise
            audioSource.clip = outsideAmbientNoise;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
