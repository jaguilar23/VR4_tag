using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScatter : MonoBehaviour
{
    public GameObject objectToScatter; // Object to scatter
    public int numberOfObjects = 10; // Number of objects to scatter
    public GameObject Ground; // Surface on which to scatter the objects

    void Start()
    {
        ScatterObjects();
    }

    void ScatterObjects()
    {
        if (Ground == null)
        {
            Debug.LogError("Surface object is not assigned.");
            return;
        }

        Renderer surfaceRenderer = Ground.GetComponent<Renderer>();
        if (surfaceRenderer == null)
        {
            Debug.LogError("Surface object does not have a Renderer component.");
            return;
        }

        Bounds bounds = surfaceRenderer.bounds;

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPoint = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
                                              Random.Range(bounds.min.y, bounds.max.y),
                                              Random.Range(bounds.min.z, bounds.max.z));

            Vector3 pointOnSurface = Ground.transform.TransformPoint(randomPoint);

            Instantiate(objectToScatter, pointOnSurface, Quaternion.identity);
        }
    }
}
