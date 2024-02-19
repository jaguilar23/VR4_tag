using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private Rigidbody rb;
    public Quaternion currentRotation;
    public Vector3 currentFallDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.rotation = currentRotation;
        rb.AddForce(currentFallDirection);
    }
}
