using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public float speedBoostAmount = 5f;
    public float duration = 5f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("YEET");
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplySpeedBoost(speedBoostAmount, duration);
            }

            Destroy(gameObject);
        }
    }
}
