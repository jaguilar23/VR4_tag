using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TagManager : MonoBehaviour
{

    public GameObject[] playerList;
    public GameObject playerLabel;
    private PlayerLabel script;

    private void Start()
    {
        script = playerLabel.GetComponent<PlayerLabel>();
    }

    // Update is called once per frame
    void Update()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");

        
        if (Input.GetKeyDown(KeyCode.K))
        {
            designateSeeker();
        }
    }

    public void designateSeeker()
    {
        // setting everyone to hider
        for (int i = 0; i < playerList.Length; i++)
        {
            playerList[i].GetComponent<PlayerLabel>().isSeeker = false;
        }

        // selecting random player as seeker
        playerList[Random.Range(0, playerList.Length)].GetComponent<PlayerLabel>().isSeeker = true;
    }
}
