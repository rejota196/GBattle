using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelector : MonoBehaviour
{
    public RectTransform[] positions;

    void Start(){
        SetPosition(0);
    }

    public void SetPosition(int posNumber){
        GetComponent<RectTransform>().position = positions[posNumber].position;
    }
}
