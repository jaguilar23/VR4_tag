using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelGravityAttractor : MonoBehaviour
{
    public float gravity;
    PlayerController pc;

    private void Start()
    {
        gravity = 10f;
    }

    private void Update()
    {
        // find player object once they're on the server
        try
        {
            pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        } catch
        {
            Debug.Log("Finding player...");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Is that freezia");
        if (other.gameObject.tag == "Player")
        {
            Vector3 direction = -transform.up;
            Vector3 bodyUp = other.transform.up;

            //Debug.Log("Transform direction before TransformDirection for " + this.gameObject.name + ": " + -transform.up);
            //Debug.Log("Parallel direction after: " + direction);

            other.transform.rotation = Quaternion.FromToRotation(bodyUp, -direction) * other.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * gravity);

            //pc.currentRotation = Quaternion.FromToRotation(bodyUp, -direction) * other.transform.rotation;
            //pc.currentFallDirection = direction * gravity;
        }
    }
}
