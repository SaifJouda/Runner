using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject[] lights;

    private int row=0;

    public void TurnOnLights()
    {
        InvokeRepeating("EnableLights", 0f, 0.2f);
        InvokeRepeating("DisableLights", 2f, 0.2f);
    }

    private void EnableLights()
    {
        lights[row].SetActive(true);
        lights[row+1].SetActive(true);
        row+=2;
        if (row >= lights.Length)
        {
            CancelInvoke("EnableLights");
            row=0;
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
