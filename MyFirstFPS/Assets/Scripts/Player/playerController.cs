using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 10;

    [SerializeField]
    private float turnerSpeed = 5;

    [SerializeField]
    private float sensetivity = -5;

    [SerializeField]
    private float jumpHeight = 3f;

    [SerializeField]
    private float gravity = -9.8f;

    private CharacterController characterController;

    private Transform playerCamera;

    private float cumRotation = 0f;

    private bool isCrouch = false;

    private Vector3 velocity;
    [SerializeField]
    private float stassHeight;




    void Start()
    {
        playerCamera = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 movement = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        if (movement.magnitude > 1)
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Crouch();
            }
        if (IsGrounded())
        {
            velocity.y = 0f;

        }
        velocity.y += gravity * Time.deltaTime;
        if (Input.GetButton("Jump") && IsGrounded())
        {
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        float sprint = Input.GetKey(KeyCode.LeftShift) && !isCrouch ? 2 : 1;
        characterController.Move((movement * playerSpeed * sprint + velocity) * Time.deltaTime);
        transform.Rotate(0, turnerSpeed * Input.GetAxis("Mouse X"), 0);
        cumRotation = Mathf.Clamp(cumRotation + Input.GetAxis("Mouse Y") * sensetivity, -89f, 89f);
        playerCamera.localEulerAngles = new Vector3(cumRotation, 0, 0);
    }

    void Crouch()
    {
        transform.localScale = new Vector3(1, isCrouch ? 1f : 0.5f, 1);
        transform.position += Vector3.up * 0.5f * (isCrouch ? 1f : -1f);
        isCrouch = !isCrouch;
    }

    bool IsGrounded()
    {
        Vector3 stassPosition = transform.position + characterController.center;
        if (Physics.SphereCast(stassPosition, characterController.radius, transform.TransformDirection(Vector3.down), out RaycastHit stass, stassHeight))
        {
            return true;
        }
        return false;

    }





}