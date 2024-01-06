using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waker : MonoBehaviour
{
    public EnemyAI enemyAI;
    
    public void WakeUp()
    {
        enemyAI.enabled=true;
    }
}
