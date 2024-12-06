using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float Offset;
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x +Offset, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
