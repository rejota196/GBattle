using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriviaAnswer : MonoBehaviour, IPointerEnterHandler
{
    public ImageSelector imageSelector;
    public int posSelector;
    public void OnPointerEnter(PointerEventData eventData)
    {
        imageSelector.SetPosition(posSelector);    
    }
    

    
}
