/*using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AllyAnimation : MonoBehaviour
{
    public Transform aimTarget; // Object to aim at
    public NavMeshAgent agent;

    public RigidBody rb;
    public Animator animator;
    private float rotationSpeed = 5f;



    void Update()
    {
        Vector3 agentVelocity = rb.velocity.normalized;
        if (aimTarget != null)
        {
            // Calculate direction to the aim target
            Vector3 aimDirection = (aimTarget.position - transform.position).normalized;
            aimDirection.y = 0f;

            // Rotate towards the aim target
            Quaternion aimRotation = Quaternion.LookRotation(aimDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, aimRotation, rotationSpeed * Time.deltaTime);
        }
       else
       {
            Vector3 aimDirection = (agentVelocity- transform.position).normalized;
            aimDirection.y = 0f;

            Quaternion aimRotation = Quaternion.LookRotation(aimDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, aimRotation, rotationSpeed * Time.deltaTime);
       }

        // Calculate the angle between the forward vector and the agent's desired velocity
        float angle = Vector3.SignedAngle(transform.forward, agentVelocity, Vector3.up);

        // Set parameters for the Animator blend tree based on the angle
        float blendX = Mathf.Sin(Mathf.Deg2Rad * angle);
        float blendY = Mathf.Cos(Mathf.Deg2Rad * angle);

        // Set parameters for the Animator blend tree
        animator.SetFloat("X", blendX);
        animator.SetFloat("Y", blendY);
    }
}
*/

using UnityEngine;

public class AllyAnimation : MonoBehaviour
{
    public Transform aimTarget; // Object to aim at
    public Animator animator;
    private float rotationSpeed = 15f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (aimTarget != null)
        {
            // Calculate direction to the aim target
            Vector3 aimDirection = (aimTarget.position - transform.position).normalized;
            aimDirection.y = 0f;

            // Rotate towards the aim target
            Quaternion aimRotation = Quaternion.LookRotation(aimDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, aimRotation, rotationSpeed * Time.deltaTime);

            // Calculate the angle between the forward vector and the parent's forward direction
            Vector3 parentForward = transform.parent.forward.normalized;

            float angle = Vector3.SignedAngle(transform.forward, parentForward, Vector3.up);

            // Set parameters for the Animator blend tree based on the angle
            float blendX = Mathf.Sin(Mathf.Deg2Rad * angle);
            float blendY = Mathf.Cos(Mathf.Deg2Rad * angle);

            // Set parameters for the Animator blend tree
            animator.SetFloat("X", blendX);
            animator.SetFloat("Y", blendY);
        }
        else
        {
            /*
            // If there is no aim target, use the parent's forward direction
            Vector3 parentForward = transform.parent.forward.normalized;

            if (parentForward != Vector3.zero)
            {
                // Calculate the angle between the forward vector and the parent's forward direction
                float angle = Vector3.SignedAngle(transform.forward, parentForward, Vector3.up);

                // Set parameters for the Animator blend tree based on the angle
                float blendX = Mathf.Sin(Mathf.Deg2Rad * angle);
                float blendY = Mathf.Cos(Mathf.Deg2Rad * angle);

                // Set parameters for the Animator blend tree
                animator.SetFloat("X", blendX);
                animator.SetFloat("Y", blendY);
            }*/
            Vector3 parentForward = transform.parent.forward.normalized;
            transform.rotation=transform.parent.rotation;
            animator.SetFloat("X", 0f);
            animator.SetFloat("Y", 1f);
        }
    }
}
