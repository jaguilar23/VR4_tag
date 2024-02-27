using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabel : MonoBehaviour
{
    public bool isSeeker;
    float seekerStartTime = 10.0f;
    public float currentSeekerTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentSeekerTimer = seekerStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSeeker)
        {
            if (currentSeekerTimer <= 0.0f)
            {
                GetComponentInParent<LifeCounter>().TakeDamage(1);
                resetTimer();
            } else
            {
                currentSeekerTimer -= Time.deltaTime;
            }
        }
    }

    void resetTimer()
    {
        currentSeekerTimer = seekerStartTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag=="Player" && isSeeker)
        {
            Debug.Log("SEEK'D");
            isSeeker = false;
            collision.gameObject.GetComponentInParent<LifeCounter>().TakeDamage(1);
            collision.gameObject.GetComponent<PlayerLabel>().isSeeker = true;
            collision.gameObject.transform.position += new Vector3(10.0f, 10.0f, 10.0f);
        }
    }
}
