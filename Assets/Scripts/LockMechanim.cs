using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] doorsToOpen;
    bool playerInRange;

    private void Update()
    {
        if (playerInRange)
        {
            foreach( var d in doorsToOpen )
            {
                d.isOpen = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
