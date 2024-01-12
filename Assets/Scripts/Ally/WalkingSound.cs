using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioClip[] walkingSounds; // Drag and drop your walking sound effects into this array in the Unity Editor
    public AudioSource audioSource;
    public float stepInterval = 0.5f;  // Adjust the interval between steps

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayWalkingSound", Random.Range(0f,0.9f), stepInterval);
    }

    void PlayWalkingSound()
    {
        audioSource.PlayOneShot(walkingSounds[Random.Range(0,9)]);
    }
}
