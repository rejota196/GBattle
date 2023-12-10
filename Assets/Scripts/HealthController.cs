using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    public Image lifeBar;
    public float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;

    private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if(!GetIsDead()){
            currentHealth -= amount;
            anim.SetTrigger("damage");
            
            if (currentHealth>=0){
                UpdateLifeBar();
                if(currentHealth==0)
                    Die();
            }
        }
    }

    private void UpdateLifeBar(){
        lifeBar.fillAmount = currentHealth/100;
    }

    private void Die()
    {
        anim.SetTrigger("die");
    }

    public float GetCurrentHealth(){
        return currentHealth;
    }

    public bool GetIsDead(){
        return currentHealth<=0? true:false;
    }
}
