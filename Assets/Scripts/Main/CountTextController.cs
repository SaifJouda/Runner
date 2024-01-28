using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTextController : MonoBehaviour
{
    public TextNumber[] textNumberScripts;

    public void PlayTextNumber(int i)
    {
        textNumberScripts[i].NumberUp();
    }
}
