using System;
using UnityEngine;
using UnityEngine.AI;

public class AllyAI : MonoBehaviour
{
    public AllyController allyController;
    public Transform player; // Reference to the player GameObject
    private NavMeshAgent navMeshAgent;
    public float updateInterval = 10f; // Time interval for updating destination
    private int health=1;

    public MeshRenderer rend;

    public Material mat1;
    public Material mat2;
    public Material mat3;

  

    void Start()
    {
        //player=GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Call the function to set the destination at regular intervals
        InvokeRepeating("SetDestinationToPlayer", 0.1f, updateInterval);

    }


    public void Initiate(Transform playerN, AllyController allyControllerN, int rank)
    {
        player=playerN;
        allyController=allyControllerN;
        SetRank(rank);
    }

    void SetRank(int i)
    {
        health=i;
        UpdateVisuals(i);
    }

    void SetDestinationToPlayer()
    {
        // Check if the player reference is not null and the NavMeshAgent is available
        if (player != null && navMeshAgent != null)
        {
            // Set the destination of the ally to the player's position
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        health-=damage;
        allyController.ChangeX(damage);
        if(health<1)
        {
            Destroy(gameObject);
        }
        UpdateVisuals(health);
    }

    private void UpdateVisuals(int i)
    {
        float size=(float)Math.Round(0.7f-1f/((float)i+4),3);//(float)Math.Round(1f/4f*Math.Log(health+2),3);//(float)Math.Round(1/2*Mathf.Sqrt(health)+0.5f,3);//(float)Math.Round(Math.Log(health+2),3);//(health)*0.1f-0.1f+1f;
        transform.localScale = new Vector3(size,size,size);
        switch(i%3)
        {
            case 1:
                rend.material = mat1;
                break;
            case 2:
                rend.material = mat2;
                break;
            case 0:
                rend.material = mat3;
                break;
        }
    }
}
