using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFPS_Nathan : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;
    public float jumpHeight = 1.0f;
    // Maximum jumps that can be taken mid-air.
    public int maxJumps = 5;
    private int remainingJumps;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        remainingJumps = maxJumps;
    }

    void PlayerMove()
    {
        // Get if the player is on the ground.
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            // Reset the available jumps.
            remainingJumps = maxJumps;
        }
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // Horizontal Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Time.deltaTime * playerSpeed);
        //and this makes it jump
        // Debug.Log("Jump"+Input.GetButtonDown("Jump"));
        // Debug.Log(remainingJumps > 0);
        if (Input.GetButtonDown("Jump") && remainingJumps > 0)
        {
            // Set velocity instead of add to make player shoot up in mid-air.
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            remainingJumps -= 1;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    void Update()
    {
        PlayerMove();
    }
}