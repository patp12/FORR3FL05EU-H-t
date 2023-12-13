using System.Collections;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip jumpScareSoundEffect;
    private bool hasJumpScared = false; // Variable to track whether the jump scare has occurred

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasJumpScared)
        {
            // Play the jump scare sound effect
            AudioSource.PlayClipAtPoint(jumpScareSoundEffect, transform.position);
            hasJumpScared = true;
        }
    }
}
