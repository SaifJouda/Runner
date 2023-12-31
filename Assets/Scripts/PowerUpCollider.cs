using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollider : MonoBehaviour
{
    public CheckPoint checkPointManager;
    public GameObject checkPoint;
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the one you expect (based on its tag, name, or layer)
        if (other.CompareTag("Player")) // Change "YourTag" to the tag you want to check
        {
            checkPoint.SetActive(false);
            if(other.transform.position.x>0) checkPointManager.RightPowerUp();
            else checkPointManager.LeftPowerUp();
        }
    }
}
