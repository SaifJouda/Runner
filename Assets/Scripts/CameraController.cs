using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;
    void  Start()
    {
        offset = transform.position;
        desiredPosition = player.position + offset;
        transform.position = desiredPosition;
    }
    void LateUpdate()
    {
        desiredPosition = new Vector3(0,0,player.position.z) + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
