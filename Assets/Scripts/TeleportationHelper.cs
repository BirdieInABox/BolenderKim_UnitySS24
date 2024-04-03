using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHelper : MonoBehaviour
{
    private Transform teleportLocation;
    public Transform controller;
    public GameObject player;

    public Checkpoint currCheckpoint;

    private void Start()
    {
        UpdateCheckpoint(null);
        Teleport();
    }

    public void UpdateCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint != null && checkpoint.checkpointNumber > currCheckpoint.checkpointNumber)
        {
            currCheckpoint = checkpoint;
        }
        teleportLocation = currCheckpoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Teleport();
        }
        /*   if (Input.GetKeyDown(KeyCode.Q))
           {
               TeleportLocationToPlayer();
           }
    void TeleportLocationToPlayer()
         {
             if (player != null)
             {
                 teleportLocation.position = controller.transform.position;
                 teleportLocation.rotation = controller.transform.rotation;
             }
         }*/
    }

    public void Teleport()
    {
        if (teleportLocation != null)
        {
            player.SetActive(false);
            controller.transform.position = teleportLocation.transform.position;
            controller.transform.rotation = teleportLocation.transform.rotation;
            player.SetActive(true);
        }
        else
        {
            Debug.LogWarning("please assign teleport location");
        }
    }
}
