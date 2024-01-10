using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public string targetTag = "Ally"; 
    public Animator animator;
    private NavMeshAgent agent;
    private GameObject nearestTarget;

    public int health=5;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("FindNearestTarget", 0f, 1f);
    }

    private void Update()
    {
        if (nearestTarget != null && health>0)
        {
            agent.SetDestination(nearestTarget.transform.position);
            animator.SetBool("isWalking", true);

            float distanceToTarget = Vector3.Distance(transform.position, nearestTarget.transform.position);
            if (distanceToTarget < 3f)
            {
                Debug.Log("Attack");
                nearestTarget.GetComponent<AllyAI>().Damage(1);
                animator.SetTrigger("Attack1");
                Damage(1);
                //agent.ResetPath();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
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


    public void Damage(int damage)
    {
        Debug.Log("Damaged");
        health-=damage;
        if(health<1)
        {
            animator.SetBool("isDead",true);
            animator.SetTrigger("Die");
            agent.ResetPath();
        }
    }
}
