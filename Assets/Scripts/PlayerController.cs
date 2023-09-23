using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minYScale = 0.5f;
    public float maxYScale = 2f;  

    private Rigidbody2D rb;
    private Vector3 initialScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        rb.velocity = movement;

        float newYScale = Mathf.Lerp(maxYScale, minYScale, Mathf.InverseLerp(-5f, 5f, transform.position.y));
        float newXScale = Mathf.Lerp(maxYScale, minYScale, Mathf.InverseLerp(-5f, 5f, transform.position.y));
        transform.localScale = new Vector3(newXScale, newYScale, initialScale.z);
    }
}
