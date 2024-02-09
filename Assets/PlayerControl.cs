using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 7.0f; // Adjust the jump force
    public Transform groundCheck; // A child GameObject representing the ground check position
    public LayerMask groundLayer; // The layer(s) to be considered as ground
    public float maxCameraAngleUp = 45.0f; // Maximum camera rotation angle up

    public float maxCameraAngleDown = 0.0f; // Maximum camera rotation angle down

    private Rigidbody rb;
    private bool isGrounded;

    public int score = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ground detection
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX);

        float newCameraAngle = Camera.main.transform.eulerAngles.x - mouseY;
        newCameraAngle = Mathf.Clamp(newCameraAngle, maxCameraAngleDown, maxCameraAngleUp);
        Camera.main.transform.eulerAngles = new Vector3(newCameraAngle, Camera.main.transform.eulerAngles.y, 0.0f);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}