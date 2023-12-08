using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private int levelNumber;
    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
        levelNumber = GameManager.Instance.GetLevelNumber();
        switch(levelNumber){
            case 1:
                anim.SetFloat("level", 0);
                break;
            case 2:
                anim.SetFloat("level", 0.5f);
                break;
            case 3:
                anim.SetFloat("level", 1);
                break;
        }
        
    }
}
