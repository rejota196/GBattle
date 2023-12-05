using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }   

    public void UsePower1()
    {
        anim.SetTrigger("Attack1");
    }

    public void UsePower2()
    {
        anim.SetTrigger("Attack2");
    }

    public void UsePower3()
    {
        anim.SetTrigger("Attack3");
    }
}
