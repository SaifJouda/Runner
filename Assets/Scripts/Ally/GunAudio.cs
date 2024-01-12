using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudio : MonoBehaviour
{
    // --- Audio ---
    public AudioClip GunShotClip;
    public AudioSource source;
    public Vector2 audioPitch = new Vector2(.9f, 1.1f);

    private void Start()
    {
            if(source != null) source.clip = GunShotClip;
    }

    public void FireWeapon()
        {
        }
}
