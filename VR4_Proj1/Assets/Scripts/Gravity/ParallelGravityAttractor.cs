using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelGravityAttractor : MonoBehaviour
{
    public float gravity;

    private void Start()
    {
        gravity = 10f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 direction = -transform.up;
            Vector3 bodyUp = other.transform.up;

            Debug.Log("Transform direction before TransformDirection for " + this.gameObject.name + ": " + -transform.up);
            Debug.Log("Parallel direction after: " + direction);

            //other.transform.rotation = transform.rotation * other.transform.rotation;
            other.transform.rotation = Quaternion.FromToRotation(bodyUp, -direction) * other.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * gravity);
        }
    }
}
