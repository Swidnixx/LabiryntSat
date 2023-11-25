using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public KeyColor keyColor;
    public DoorMechanim[] doorsToOpen;
    bool playerInRange;
    bool alreadyOpen;

    private void Update()
    {
        if (alreadyOpen) return;

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.Instance.CheckKey(keyColor))
            {
                alreadyOpen = true;
                foreach (var d in doorsToOpen)
                {
                    d.isOpen = true;
                } 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
