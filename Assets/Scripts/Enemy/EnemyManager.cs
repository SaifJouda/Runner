using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int xRange;
    public int zRange;

    public void SpawnEnemies(int checkPointsPassed)
    {

        for(int i=0;i< Random.Range(1+checkPointsPassed/2,3+5*checkPointsPassed/2); i++) 
           {
                Debug.Log("spawning enemy");
                Instantiate(enemyPrefab, transform.position-new Vector3(Random.Range(-1*xRange,xRange),0,Random.Range(-1*zRange,zRange)), Quaternion.identity, transform);
           }
    }
    public void WakeAllEnemies()
    {
        BroadcastMessage("WakeUp");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector3(xRange*2, 1f, zRange*2));
    }
}
