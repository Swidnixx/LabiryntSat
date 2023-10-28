using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform otherPortalTeleport;
    Transform player;
    bool teleporting;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.transform;
            teleporting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.transform;
            teleporting = false;
        }
    }

    private void FixedUpdate()
    {
        if (teleporting)
        {
            Vector3 portalForward = transform.up;
            Vector3 portalToPlayer = player.position - transform.position;

            float dot = Vector3.Dot(portalForward, portalToPlayer);

            if(dot < 0)
            {
                player.position = otherPortalTeleport.position;
                teleporting = false;

                //Rotation aligment
                Vector3 playerForward = transform.parent.InverseTransformDirection(player.forward);
                playerForward = otherPortalTeleport.parent.TransformDirection(playerForward);
                player.forward = playerForward;
            }
        }
    }
}
