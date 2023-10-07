using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Settings
    public float regularSpeed = 7;
    public float fastSpeed = 14;
    public float slowSpeed = 4;
    public float rotSpeed = 250;
    public LayerMask groundMask;

    //Dependencies
    public Transform cam;
    CharacterController controller;

    //Inner settings
    float speed;
    float camRotX;

    private void Start()
    {
        speed = regularSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        GroundDetection();
    }

    void GroundDetection()
    {
        RaycastHit hit;
        float distance = controller.height * 0.5f - controller.radius;
        bool didHit = Physics.SphereCast(transform.position, controller.radius, Vector3.down,
            out hit, distance + 0.1f, groundMask);

        if(didHit)
        {
            //Debug.Log("Pod³o¿e: " + hit.collider.tag);
            switch (hit.collider.tag)
            {
                case "Fast":
                    speed = fastSpeed;
                    break;

                case "Slow":
                    speed = slowSpeed;
                    break;

                default:
                    speed = regularSpeed;
                    break;
            }
        }
        else
        {
            speed = regularSpeed;
        }
    }

    void Movement()
    {
        //Collect Input
        float inputX = Input.GetAxis("Horizontal"); // lewo: -1; prawo: 1; nic: 0
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Movement
        Vector3 move = transform.right * inputX + transform.forward * inputY;
        controller.Move(move * Time.deltaTime * speed);

        //Rotation
        transform.Rotate(0, mouseX * Time.deltaTime * rotSpeed, 0);

        //Camera Rotation
        camRotX -= mouseY * Time.deltaTime * rotSpeed;
        camRotX = Mathf.Clamp(camRotX, -60, 60);
        cam.localRotation = Quaternion.Euler(camRotX, 0, 0);

        //Gravity
        controller.Move(Physics.gravity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (controller == null) return;

        Gizmos.color = Color.red;
        float distance = controller.height * 0.5f - controller.radius;
        Vector3 pos = transform.position + Vector3.down * (distance + 0.1f);
        Gizmos.DrawSphere(pos, controller.radius);
    }
}
