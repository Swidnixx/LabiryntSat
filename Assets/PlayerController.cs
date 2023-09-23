using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Settings
    public float moveSpeed = 1;
    public float rotSpeed = 100;

    //Dependencies
    public Transform cam;
    CharacterController controller;

    //Inner settings
    float camRotX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        Vector3 move = transform.right * inputX + transform.forward * inputY;
        controller.Move(move * Time.deltaTime * moveSpeed);

        //Rotation
        transform.Rotate(0, mouseX * Time.deltaTime * rotSpeed, 0);

        //Camera Rotation
        camRotX -= mouseY * Time.deltaTime * rotSpeed;
        camRotX = Mathf.Clamp(camRotX, -60, 60);
        cam.localRotation = Quaternion.Euler(camRotX, 0, 0);

        //Gravity
        controller.Move(Physics.gravity * Time.deltaTime);
    }
}
