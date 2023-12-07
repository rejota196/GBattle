using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour
{
    void Start()
    {
        DisableMessage();
    }

    void DisableMessage(){
        gameObject.SetActive(false);
    }
    
}
