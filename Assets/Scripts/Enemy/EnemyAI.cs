using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public string targetTag = "Ally"; 
    public Animator animator;
    private NavMeshAgent agent;
    private GameObject nearestTarget;

    public AllyController allyController;

    public int health=5;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private float attackCooldown;
    private float attackTimer=0;

    public MainController mainController;

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
            if (distanceToTarget < attackRadius && attackTimer<=0 && nearestTarget.GetComponent<AllyAI>().dead==false)
            {
                Debug.Log("Attack");
                nearestTarget.GetComponent<AllyAI>().Damage(1);
                animator.SetTrigger("Attack1");
                Damage(1);
                attackTimer=attackCooldown;
                //agent.ResetPath();
            }
            attackTimer-=Time.deltaTime;
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
            if (distanceToTarget < shortestDistance && target.GetComponent<AllyAI>().dead==false)
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
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead",true);
        animator.SetTrigger("Die");
        agent.ResetPath();
        mainController.ghoulsKilled+=1;
    }

    private void OnDrawGizmos()
    {
        // Set the color of the gizmo
        Gizmos.color = Color.yellow;

        // DrawWireSphere draws an invisible sphere for gizmo visualization
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
