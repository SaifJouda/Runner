using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed=5.0f;
    public float maxRange = 9f; // Maximum X position

    //private bool isDead=false; 


    void Update()
    {
       // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane + 14.0f));

        // Set the target position for the player (only X position changes)
        Vector3 targetPosition = new Vector3( Mathf.Clamp(worldMousePosition.x,-1*maxRange,maxRange), transform.position.y, transform.position.z);

        // Move the player towards the target position
        transform.position = targetPosition;//Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
       // transform.position+= new Vector3(0,0,0.05f);
    }

    void FixedUpdate()
    {
        transform.position+= new Vector3(0,0,0.3f);
    }
}
