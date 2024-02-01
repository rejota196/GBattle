using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    public float damageAmount = 5f;
    public float knockbackForce = 5f;
    public LayerMask enemyLayer;

    private PowerController power;
    private float timeToAttack;
    private float currentTime;

    private AudioController audio;
    private GameManager gm;

    public GameObject bulletGO;

    
    void Start(){
        power = GetComponent<PowerController>();
        audio = GetComponent<AudioController>();
        gm = GameManager.Instance;
    }    

    public void Attack(float timeToAttack)
    {
        if(currentTime<timeToAttack)
            currentTime+=Time.deltaTime;
        else{
            currentTime = 0;
            audio.Attack();
            power.UsePower1();
            
            switch(gm.GetLevelNumber()){
                case 1:
                AttackL1();
                break;
                case 2:
                AttackL2L3();
                break;
                case 3:
                AttackL2L3();
                break;
            }
        }
        
    }

    private void AttackL1(){
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

    private void AttackL2L3(){
        GameObject bullet = Instantiate(bulletGO, transform.Find("Fire").position, transform.localRotation);
        
    }
}
