using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSplayer : MonoBehaviour
{
    public static float moveSpeed = 15.0f;
    public float jumpForce = 5.0f;
    public float gravity = 20.0f; 
    public float lookSpeed = 20.0f;

    private CharacterController characterController;
    private Transform cameraTransform;
    private float rotationX = 0;
    private float verticalVelocity = 0; 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));
        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime; 
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime; //zwaartkracht
        }

        moveDirection.y = verticalVelocity;
        characterController.Move(moveDirection * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.rotation = Quaternion.Euler(0, mouseX + transform.eulerAngles.y, 0);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
