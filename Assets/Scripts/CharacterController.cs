using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 13f;
    public float gravityMultiplier = 2.0f;
    public Transform playerFeet;
    public LayerMask groundLayer;

    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;

    private AudioController audio;

    private GameManager gm;
    private CombatController cController;


    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private int playerNumber;
    private float horizontalMovement;

    void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioController>();
        rb.gravityScale*= gravityMultiplier;        
        
    }

    

    void FixedUpdate()
    {
        if(gm.GetCurrentState() == GameManager.GameState.Playing){
            
            if(Input.GetKey(left))
                horizontalMovement = -1;
            else if (Input.GetKey(right))
                horizontalMovement = 1;
            else    
                horizontalMovement = 0;          
            
            if (horizontalMovement < 0)
                transform.eulerAngles = new Vector3(0,180,0);
            else if (horizontalMovement > 0)
                transform.eulerAngles = new Vector3(0,0,0);

            anim.SetFloat("speed", Mathf.Abs(horizontalMovement));

            isGrounded = Physics2D.OverlapCircle(playerFeet.position, 0.2f, groundLayer);
            
            if (Input.GetKey(jump) && isGrounded)
            {
                audio.Jump();
                Jump();
            }

            Vector2 movement = new Vector2(horizontalMovement * speed, rb.velocity.y);
            rb.velocity = movement;
            
        }
        
    }

    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    
    public void SetControl1(){
        left = KeyCode.A;
        right = KeyCode.D;
        jump = KeyCode.H;
        GetComponent<CombatController>().SetAttackKey(KeyCode.G);
    }
    public void SetControl2(){
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;
        jump = KeyCode.Keypad2;
        GetComponent<CombatController>().SetAttackKey(KeyCode.Keypad1);
    }
}
