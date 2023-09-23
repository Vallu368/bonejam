using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 offset; // Camera offset
    public bool followOnYAxis = true; // Enable/disable following on the Y-axis
    public float initialYPosition; // Initial Y position for the camera

    public bool isFollowingYAxis = true; // Track whether currently following on Y-axis

    private float currentYPosition; // Store the current Y position of the camera

    private void Start()
    {
        currentYPosition = transform.position.y;
    }

    private void Update()
    {
        if (!followOnYAxis && !isFollowingYAxis)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y = Mathf.Lerp(targetPosition.y, initialYPosition, smoothSpeed * Time.deltaTime);
            transform.position = targetPosition;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            if (!isFollowingYAxis)
            {
                targetPosition.y = transform.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    public void DisableFollowOnYAxis()
    {
        isFollowingYAxis = false;
    }

    public void EnableFollowOnYAxis()
    {
        isFollowingYAxis = true;
    }
}
