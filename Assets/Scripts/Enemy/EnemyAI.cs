using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public string targetTag = "Ally"; 
    public Animator animator;
    private NavMeshAgent agent;
    private GameObject nearestTarget;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindNearestTarget();
    }

    private void Update()
    {
        if (nearestTarget != null)
        {
            agent.SetDestination(nearestTarget.transform.position);
            animator.SetBool("isWalking", true);
        }
        else
        {
            FindNearestTarget();
        }
    }

    private void FindNearestTarget()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
        float shortestDistance = Mathf.Infinity;
        nearestTarget = null;

        foreach (GameObject target in targetObjects)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<AllyAI>().Damage(1);
            //Destroy(gameObject);
            animator.SetTrigger("Attack1");
        }
    }
}
