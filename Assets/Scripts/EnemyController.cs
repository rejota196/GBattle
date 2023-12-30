using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 30f;
    public float jumpCooldown;
    public LayerMask groundLayer; 

    public Transform player;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private Vector2 posH;
    private EnemyCombatController enemyCombat;
    private Animator anim;
    private HealthController health;
    

    private float timeToAttack;

    private AudioController audio;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombatController>();
        health = GetComponent<HealthController>();
        audio = GetComponent<AudioController>();
        int levelNumber = GameManager.Instance.GetLevelNumber();

        switch(levelNumber){
            case 1:
                timeToAttack = 1f;
                jumpCooldown = 3;
                moveSpeed = 2f;
                break;
            case 2:
                timeToAttack = 0.5f;
                jumpCooldown = 1.5f;
                moveSpeed = 2.5f;
                break;
            case 3:
                timeToAttack = 0.3f;
                jumpCooldown = 1;
                moveSpeed = 3f;
                break;
        
        }

        
    }

    void FixedUpdate()
    {
        if (gm.GetCurrentState() == GameManager.GameState.Playing){
            if(!health.GetIsDead()){
                posH = new Vector2(player.position.x, transform.position.y);
                if (Vector2.Distance(posH, transform.position) > 1)
                {
                    MoveTowardsPlayer();

                    if (Time.time >= jumpCooldown && IsGrounded())
                    {
                        audio.Jump();
                        Jump();
                    }
                }
                else
                {
                    anim.SetFloat("speed", 0);
                    enemyCombat.Attack(timeToAttack);
                }
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        anim.SetFloat("speed", 1);
        float horizontalInput = Mathf.Sign(player.position.x - transform.position.x);
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        Flip(horizontalInput);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCooldown = Time.time + jumpCooldown;
    }

    private bool IsGrounded()
{
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        return hit.collider != null;
    }

    private void Flip(float horizontal)
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    

    
}
