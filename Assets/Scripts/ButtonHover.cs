using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    void Start(){
        anim = GetComponent<Animator>(); 
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("isIn");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("isOut");
    }
}
