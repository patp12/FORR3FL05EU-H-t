using System.Collections;
using UnityEngine;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private Transform teleportDestination; // Destination where you want to teleport the player
    [SerializeField] private AudioClip doorSoundEffect; // Door sound effect
    public Camera playerCamera;


    private AudioSource doorAudioSource;

    void Start()
    {
        // Create an AudioSource component for the door sound effect
        doorAudioSource = gameObject.AddComponent<AudioSource>();
        doorAudioSource.playOnAwake = false;
        doorAudioSource.clip = doorSoundEffect;
    }

    void Update()
    {
        // Cast a ray from the center of the camera forward
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;

        // Check if the ray hits an object within the interaction distance
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Check if the hit object is a door
            if (hit.collider.CompareTag("Door"))
            {
                // Enable the interaction text and set its position
                interactionText.gameObject.SetActive(true);
                interactionText.transform.position = Camera.main.WorldToScreenPoint(hit.collider.transform.position);

                // Check for player input (E key)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TeleportPlayer();
                    PlayDoorSoundEffect();
                }
            }
            else
            {
                // If the player is not looking at a door or is too far away, hide the interaction text
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            // If the ray doesn't hit anything, hide the interaction text
            interactionText.gameObject.SetActive(false);
        }
    }

    void TeleportPlayer()
    {
        // Teleport the player to the destination
        // For example, you might set the player's position to the teleport destination
        PlayerTeleportation.Teleport(teleportDestination.position);
    }


    void PlayDoorSoundEffect()
    {
        // Play the door sound effect
        if (doorAudioSource && doorSoundEffect)
        {
            doorAudioSource.PlayOneShot(doorSoundEffect);
        }
    }
}
