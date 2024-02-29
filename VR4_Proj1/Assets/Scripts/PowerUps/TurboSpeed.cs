using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboSpeed : MonoBehaviour
{
    public float speedMultiplier = 2f; // Multiplier for player's walk speed
    public float duration = 5f; // Duration of speed boost
    private float originalSpeed;
    private bool boostActive = false;

    [SerializeField]
    private GameObject disableBoost = null;

    private MeshRenderer myRenderer;
    private BoxCollider myCollider;

    private void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player")) // If collided object is the player
        {
            Debug.Log("collide");
            if (!boostActive) // Check if boost is not already active
            {              
                StartCoroutine(BoostSpeed(playerController));
                Debug.Log("Speed");
            }
        }

        // "Delete" powerup
        myRenderer.enabled = false;
        myCollider.enabled = false;
    }

    IEnumerator BoostSpeed(PlayerController playerController)
    {

        Debug.Log("Start Couroutine");
        boostActive = true;
        ActivateTurboSpeed(playerController);
       // playerController.walkSpeed += speedMultiplier; // Double the player's walk speed
        yield return new WaitForSeconds(duration);
        DeactivateTurboSpeed(playerController);
        // playerController.walkSpeed = 14; // Reset the player's walk speed 
        boostActive = false;
    }

    private void ActivateTurboSpeed(PlayerController playerController)
    {
        playerController.walkSpeed *= speedMultiplier;
    }

    private void DeactivateTurboSpeed(PlayerController playerController)
    {
        playerController.walkSpeed /= speedMultiplier;
    }
}
