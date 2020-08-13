using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    [Header("Character options")]
    public float gravity = 20.0f;
    public float movementSpeed = 15;
    public float jumpSpeed = 8.0f;

    [Header("Camera options")]
    public Camera cam;
    public float mouseH = 3.0f;
    public float mouseV = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_Mouse, v_Mouse;

    private Vector3 move = Vector3.zero;

    void Start()
    {
        //This hides the cursor from the screen so the player can only see it when pressed Esc.
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        //This controls the movement for the mouse.
        h_Mouse = mouseH * Input.GetAxis("Mouse X");
        v_Mouse += mouseV * Input.GetAxis("Mouse Y");

        v_Mouse = Mathf.Clamp(v_Mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(-v_Mouse, 0, 0);

        transform.Rotate(0, h_Mouse, 0);


        Movement();

    }

    void Movement()
    {
        //This controller helps me to know if the player is actually on the ground, so it can be able to move as i wish. 
        if (controller.isGrounded)
        {
            //It takes the directions of the keyboard so i can move in a proper way, regardless of the position im in. 
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move) * movementSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                //If you want to jump.
                move.y = jumpSpeed;
            }
            else if(Input.GetKey(KeyCode.Tab))
            {
                //In case you just want to quit the game early.
                Application.Quit(); 
            }
        }
        //The control for the time the player jumps and lands. 
        move.y -= gravity * Time.deltaTime;

        controller.Move(move * Time.deltaTime);
    }
}
