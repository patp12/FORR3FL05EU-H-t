using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoise : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
