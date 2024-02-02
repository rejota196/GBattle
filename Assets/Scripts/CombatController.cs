using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public int character;
    public float damageAmount = 5f;
    public float knockbackForce = 5f;
    public LayerMask enemyLayer;


    private PowerController power;

    private AudioController audio;

    private GameManager gm;

    public KeyCode attack;
    public GameObject bulletGO;
    void Start(){
        gm = GameManager.Instance;
        power = GetComponent<PowerController>();
        audio = GetComponent<AudioController>();
        
    }

    private void Update()
    {
        if(gm.GetCurrentState() == GameManager.GameState.Playing){
            if (Input.GetKeyDown(attack))
            {
                audio.Attack();
                power.UsePower1();
                if(character<3)
                    Attack1();
                else
                    Attack2();
            }
        }
    }

    private void Attack1()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1f, enemyLayer);

        if (hit.collider != null)
        {
            HealthController enemyHealth = hit.collider.GetComponent<HealthController>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

                Rigidbody2D enemyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                if (enemyRigidbody != null)
                {
                    Vector2 knockbackDirection = transform.right;
                    enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                    
                }
            }
        }
    }

    public void Attack2(){
        GameObject bullet = Instantiate(bulletGO, transform.Find("Fire").position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(transform.TransformDirection(Vector3.right));
    }

    public void SetEnemyLayer(LayerMask enemyLayer){
        this.enemyLayer = enemyLayer;
    }
    public void SetAttackKey(KeyCode attack){
        this.attack = attack;
    }


    
}
