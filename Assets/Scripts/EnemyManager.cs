using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        for(int i=0;i< Random.Range(1, 10); i++) Instantiate(enemyPrefab, transform.position-new Vector3(10,0,0), Quaternion.identity, transform);
    }
    public void WakeAllEnemies()
    {
        BroadcastMessage("WakeUp");
    }
}
