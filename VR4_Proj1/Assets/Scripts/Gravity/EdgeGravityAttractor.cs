using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeGravityAttractor : MonoBehaviour
{
    public float gravity;
    private BoxCollider bc;

    private void Start()
    {
        gravity = -10f;
        bc = this.GetComponent<BoxCollider>();
    }

    public void Attract(Transform body)
    {
        float distanceFromCenter = Vector3.Distance(body.position, transform.position); // distance from center of gravity object

        if (distanceFromCenter <= 100f)
        {
            Vector3 targetDir = (body.position - transform.position).normalized;
            Vector3 bodyUp = body.up;

            Debug.Log(targetDir.x + ", " + targetDir.y + ", " + targetDir.z);

            body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation;
            body.GetComponent<Rigidbody>().AddForce(targetDir * gravity);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 gravitionalPoint = getGravitationalCenter(other.transform.position);

            Vector3 targetDir = (other.transform.position - gravitionalPoint).normalized;
            Vector3 bodyUp = other.transform.up;

            Debug.Log(targetDir.x + ", " + targetDir.y + ", " + targetDir.z);

            other.transform.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * other.transform.rotation;
            other.GetComponent<Rigidbody>().AddForce(targetDir * gravity);
        }
    }

    private Vector3 getGravitationalCenter(Vector3 playerPos)
    {
        //Vector3 A = transform.TransformPoint(transform.localPosition.x - 2 * bc.size.x, transform.localPosition.y - 2 * bc.size.y, transform.localPosition.z - (bc.size.z / 2.0f));
        Vector3 A = transform.TransformPoint(-(bc.size.x / 2), -(bc.size.y / 2), transform.localPosition.z - (bc.size.z / 2.0f));

        Vector3 C = transform.TransformPoint(-(bc.size.x / 2), -(bc.size.y / 2), transform.localPosition.z + (bc.size.z / 2.0f));

        Debug.Log("Center throughline from " + A + " to " + C);

        Vector3 bcLine = C - A;

        float t = (Vector3.Dot((playerPos - A), bcLine) / Vector3.Dot(bcLine, bcLine));

        Vector3 centerPoint = A + t * (bcLine);

        return centerPoint;
    }
}
