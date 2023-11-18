using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public Transform door;
    public Transform openTag;
    public Transform closedTag;

    public float openSpeed = 1;
    public bool isOpen;

    private void Update()
    {
        Vector3 targetPos;
        if(isOpen)
        {
            targetPos = openTag.position;
        }
        else
        {
            targetPos = closedTag.position;
        }

        door.position = 
            Vector3.MoveTowards(door.position, targetPos, Time.deltaTime * openSpeed);
    }
}
