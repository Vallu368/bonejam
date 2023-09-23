using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisThingy : MonoBehaviour
{
    public CameraFollow cameraF;

    private void Awake()
    {
        cameraF = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (cameraF.isFollowingYAxis)
            {
                cameraF.DisableFollowOnYAxis();
            }
            else
            {
                cameraF.EnableFollowOnYAxis();
            }
        }
    }
}
