using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 30f;
    public float jumpCooldown;
    public Transform feet;
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

    private float timeToFire;

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
                timeToAttack = Random.Range(1,2);
                jumpCooldown = Random.Range(2,4);
                moveSpeed = Random.Range(1,4);
                break;
            case 2:
                timeToAttack = Random.Range(1,1.5f);
                jumpCooldown = Random.Range(2,4);
                moveSpeed = Random.Range(2,3);
                break;
            case 3:
                timeToAttack = Random.Range(0.5f,1);
                jumpCooldown = Random.Range(2,4);
                moveSpeed = Random.Range(3,5);
                break;
        
        }

        
    }

    void FixedUpdate()
    {
        if (gm.GetCurrentState() == GameManager.GameState.Playing){
            if(!health.GetIsDead()){
                posH = new Vector2(player.position.x, transform.position.y);
                switch(gm.GetLevelNumber()){
                    case 1:
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
                    break;
                    case 2:
                    if(timeToFire<timeToAttack){
                        timeToFire+=Time.deltaTime;
                        MoveTowardsPlayer();
                        if (Time.time >= jumpCooldown && IsGrounded())
                        {
                            audio.Jump();
                            Jump();
                        }
                    }
                    else{
                        timeToFire = 0;
                        enemyCombat.Attack(0);
                    }
                    break;
                    case 3:
                    if(timeToFire<timeToAttack){
                        timeToFire+=Time.deltaTime;
                        MoveTowardsPlayer();
                        if (Time.time >= jumpCooldown && IsGrounded())
                        {
                            audio.Jump();
                            Jump();
                        }
                    }
                    else{
                        timeToFire = 0;
                        enemyCombat.Attack(0);
                    }
                    break;
                    
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
        RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, 2f, groundLayer);
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
