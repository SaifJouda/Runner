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

    private GameObject target;
    public GameObject projectilePrefab;
    private float shootingForce = 200f; // Force applied to the projectile
    private float shootingInterval = 0.1f; // Time interval between shots
    private float shootingTimer = 0f;

    void Start()
    {
        //player=GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Call the function to set the destination at regular intervals
        InvokeRepeating("SetDestinationToPlayer", 0.1f, updateInterval);
        InvokeRepeating("FindTarget", 0.1f, updateInterval);
    }

    void Update()
    {
        // Check if the target is set and shooting timer allows shooting
        if (target && shootingTimer <= 0f)
        {
            if(target.GetComponent<EnemyAI>().health>0 && target.GetComponent<EnemyAI>().enabled)
            {
                ShootProjectile();
                shootingTimer = shootingInterval; // Reset the shooting timer
            }
        }

        // Update the shooting timer
        if(shootingTimer>0) shootingTimer -= Time.deltaTime;
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                if(collider.gameObject.GetComponent<EnemyAI>().health>0) target = collider.gameObject;
                // Do something with the targetObject (e.g., set as AI target, perform actions, etc.)
                //Debug.Log("Found target: " + target.name);
            }
        }
    }

    void ShootProjectile()
    {
        // Calculate direction towards the target
        Vector3 direction = (target.transform.position - transform.position).normalized;

        // Instantiate the projectile
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody of the projectile
        Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();

        // Check if the projectile Rigidbody exists
        if (projectileRb)
        {
            // Apply force to shoot the projectile towards the target
            projectileRb.AddForce(direction * shootingForce, ForceMode.Impulse);

            // Rotate the projectile towards the target
            Quaternion rotation = Quaternion.LookRotation(direction);
            newProjectile.transform.rotation = rotation;
        }

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
