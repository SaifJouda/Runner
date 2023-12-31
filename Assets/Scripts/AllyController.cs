using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    public Transform player;
    public GameObject allyPrefab;
    
    private int x=1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllAllies();
    }


    private void SpawnAllAllies()
    {
        for(int i=0;i<x;i++)
        {
            SpawnAlly();
        }
    }

    private void SpawnAlly()
    {
        GameObject spawnedAlly=Instantiate(allyPrefab, player.position, Quaternion.identity,transform);
        spawnedAlly.GetComponent<AllyAI>().player=player;
    }

    private void DespawnAllAllies()
    {
        if(x>0) BroadcastMessage("Destruct");
    }

    private void RespawnAllies()
    {
        DespawnAllAllies();
        SpawnAllAllies();
    }
}
