using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportDistance = 3f; // Distance to teleport
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming player has a "Player" tag
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // If collided object is the player
        {
            Debug.Log("collide");
            Vector3 teleportPosition = playerTransform.position + playerTransform.forward * teleportDistance;
            playerTransform.position = teleportPosition;
        }
    }
}
