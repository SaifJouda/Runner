using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllyController : MonoBehaviour
{
    public Transform player;
    public GameObject allyPrefab;

    public TextMeshProUGUI xText;
    
    private int x=10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllAllies();
        UpdateXText();
    }

    public void PickUp(int newX)
    {
        x=newX;
        if(x<1) x=1;
        if(x>10) x=10;
        RespawnAllies();
        UpdateXText();
    }

    public void ChangeX(int xChange)
    {
        x-=xChange;
        if(x<1) Die();
        UpdateXText();
    }

    public int getX()
    {
        return x;
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
        spawnedAlly.GetComponent<AllyAI>().allyController=this;
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

    private void Die()
    {
        Debug.Log("die");
        player.gameObject.GetComponent<PlayerController>().enabled = false;
    }

    private void UpdateXText()
    {
        xText.text=x+"";
    }
}
