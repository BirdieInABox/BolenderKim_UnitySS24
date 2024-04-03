using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public TeleportationHelper tpHelper;
    public int checkpointNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tpHelper.UpdateCheckpoint(this);
        }
    }
}
