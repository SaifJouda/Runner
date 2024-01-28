using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextNumber : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    private int currentNumber=0;
    public int finalNumber=50;

    void Start()
    {
        text= GetComponent<TextMeshProUGUI>();
    }

    public void NumberUp()
    {
        InvokeRepeating("Counter", 0f,0.01f);
    }


    private void Counter()
    {
        text.text = currentNumber+"";
        if(currentNumber==finalNumber)
        {
            CancelInvoke("Counter");
        }
        currentNumber++;
    }
}
