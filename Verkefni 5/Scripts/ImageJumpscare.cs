using UnityEngine;
using UnityEngine.UI;

public class ImageJumpscare : MonoBehaviour
{
    public AudioClip jumpScareSound;
    public Image jumpScareImage; // Reference to your jumpscare image

    private AudioSource audioSource;

    void Start()
    {
        // Ensure there is an AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the jumpscare image is initially hidden
        jumpScareImage.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the jumpscare sound
            if (audioSource && jumpScareSound)
            {
                audioSource.PlayOneShot(jumpScareSound);
            }

            // Show the jumpscare image
            ShowJumpScareImage();

            // Disable the collider to prevent triggering again
            GetComponent<Collider>().enabled = false;
        }
    }

    void ShowJumpScareImage()
    {
        // Enable the jumpscare image
        jumpScareImage.gameObject.SetActive(true);

        // Invoke a method to hide the image after 2 seconds
        Invoke("HideJumpScareImage", 2f);
    }

    void HideJumpScareImage()
    {
        // Disable the jumpscare image
        jumpScareImage.gameObject.SetActive(false);
    }
}
