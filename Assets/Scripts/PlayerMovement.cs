using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Movement speed variables
    public float walkSpeed;
    public float jumpForce;

    // Input value variables
    private float horizontalInput;

    // Jump movement variables
    public float timer;
    public bool forcedToGround;

    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use A & D key inputs to make character walk left or right respectively
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * walkSpeed * horizontalInput * Time.deltaTime);

        // Character jumps while space key is held AND while they're allowed airtime
        if (Input.GetKey(KeyCode.Space) && !forcedToGround)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Character is given set amount of airtime in their jump before being forced to go to the ground
            timer += 1 * Time.deltaTime;
            if (timer > 0.15f)
            {
                forcedToGround = true;
                timer = 0;
            } 
        }

        // Prevents character from jumping more than once when already in the air.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            forcedToGround = true;
        }
    }

    // OnCollisionEnter2D is called when the attached gameObject first enters a collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    // OnCollisionStay2D is called when the attached gameObject experiences a continuous collision
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            forcedToGround = false;
            timer = 0;
        }
    }
}
