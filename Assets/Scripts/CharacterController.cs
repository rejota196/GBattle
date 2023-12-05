using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float gravityMultiplier = 2.0f;
    public Transform playerFeet;
    public LayerMask groundLayer;

    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        rb.gravityScale*= gravityMultiplier;
    }

    

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (horizontalMovement < 0)
            transform.eulerAngles = new Vector3(0,180,0);
        else if (horizontalMovement > 0)
            transform.eulerAngles = new Vector3(0,0,0);

        anim.SetFloat("speed", Mathf.Abs(horizontalMovement));

        isGrounded = Physics2D.OverlapCircle(playerFeet.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        Vector2 movement = new Vector2(horizontalMovement * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
