using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Collect Input
        float inputX = Input.GetAxis("Horizontal"); // lewo: -1; prawo: 1; nic: 0
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Movement
        Vector3 move = new Vector3(inputX, 0, inputY);
        controller.Move(move * Time.deltaTime * speed);
    }
}
