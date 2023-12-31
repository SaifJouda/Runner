using UnityEngine;
using UnityEngine.AI;

public class AllyAI : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    private NavMeshAgent navMeshAgent;
    public float updateInterval = 0.01f; // Time interval for updating destination

    void Start()
    {
        //player=GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Call the function to set the destination at regular intervals
        InvokeRepeating("SetDestinationToPlayer", 0.1f, updateInterval);
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
}
