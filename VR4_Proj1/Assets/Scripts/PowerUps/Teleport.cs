using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportDistance = 3f; // Distance to teleport
    private Transform playerTransform;
    public int powerUpCredits = 0;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming player has a "Player" tag
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && powerUpCredits > 0)
        {
            // move the player
           /*
            Vector3 teleportPosition = playerTransform.position + playerTransform.forward * teleportDistance;
            playerTransform.position = teleportPosition;
           */
            powerUpCredits--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // If collided object is the player
        {
            Debug.Log("collide");
            powerUpCredits++;
           
            Vector3 teleportPosition = playerTransform.position + playerTransform.forward * teleportDistance;
            playerTransform.position = teleportPosition;
           
        }
    }
}
