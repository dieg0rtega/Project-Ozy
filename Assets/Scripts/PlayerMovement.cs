using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Movement speed variables
    public float walkSpeed; // Sideways speed
    public float jumpForce; // Force when jumping

    // Input value variables
    private float horizontalInput; // Horizontal axis input

    private bool isOnGround;

    private Rigidbody2D playerRB;
    private Collider2D playerCol;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * walkSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
