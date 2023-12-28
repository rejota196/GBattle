using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgainSelection : MonoBehaviour,IPointerEnterHandler
{
    public Transform selector;
    public Transform s1;
    public Transform s2;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(name=="TryAgain")
            selector.position = s1.position;        
        else    
            selector.position = s2.position;
    }    
}
