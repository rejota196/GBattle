using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public float damageAmount = 10f;
    public float knockbackForce = 5f;
    public LayerMask enemyLayer;

    private PowerController power;

    void Start(){
        power = GetComponent<PowerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            power.UsePower1();
            Attack();
        }
    }

    private void Attack()
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
                    SetXConstraints(enemyRigidbody, false);
                    enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                    StartCoroutine(ActivateXConstraints(enemyRigidbody));
                }
            }
        }
    }

    IEnumerator ActivateXConstraints(Rigidbody2D rb){
        yield return new WaitForSeconds(0.3f);
        SetXConstraints(rb, true);
    }

    void SetXConstraints(Rigidbody2D rb, bool isConstrained)
    {
        if (isConstrained)
        {
            rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
