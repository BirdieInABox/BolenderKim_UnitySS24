using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathwall : MonoBehaviour
{
    public TeleportationHelper tpHelper;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tpHelper.Teleport();
        }
    }
}
