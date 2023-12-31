using UnityEngine;

public class Deleter : MonoBehaviour
{
    public Transform player;
    public float distanceBehindPlayer = 10f;
    public float updateInterval = 0.2f; // Interval to update the position

    void Start()
    {
        InvokeRepeating("UpdatePosition", 0f, updateInterval);
    }

    void UpdatePosition()
    {
        // Calculate the position behind the player
        Vector3 targetPosition = player.position - player.forward * distanceBehindPlayer;
        transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");
        // Check if collided object is a platform
        if (other.CompareTag("Platform"))
        {
            GameObject collidedObjectParent = other.gameObject.transform.parent.gameObject;
            // Handle collision with the platform (e.g., deactivate or destroy it)
            Destroy(collidedObjectParent);
            // You can add additional logic here, such as scoring or effects
        }
        
    }
}
