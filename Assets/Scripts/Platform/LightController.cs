using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject[] text;
    public GameObject[] lights;

    private int row=0;

    public Animator leftBoxAnimator;
    public Animator rightBoxAnimator;

    public AudioSource smallSound;
    public AudioSource bigSound;

    public void TurnOnLights()
    {
        leftBoxAnimator.SetTrigger("stretch");
        rightBoxAnimator.SetTrigger("stretch");
        InvokeRepeating("EnableLights", 0f, 0.2f);
        InvokeRepeating("DisableLights", 2.2f, 0.2f);
    }

    private void EnableLights()
    {
        lights[row].SetActive(true);
        lights[row+1].SetActive(true);
        row+=2;
        if (row >= lights.Length)
        {
            text[0].SetActive(true);
            text[1].SetActive(true);
            //bigSound.Play();
            CancelInvoke("EnableLights");
            row=0;
        }
        else
        {
            ///smallSound.Play();
        }
    }

    private void DisableLights()
    {
        lights[row].SetActive(false);
        lights[row+1].SetActive(false);
        row+=2;
        if (row >= lights.Length)
            CancelInvoke("DisableLights");
    }
}
