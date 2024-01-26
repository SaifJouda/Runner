using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    public GameObject deathScreen;
    public void Die()
    {
        deathScreen.SetActive(true);
    }   
}
