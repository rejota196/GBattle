using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public GameObject selector1;
    public GameObject selector2;
    public Transform[] pos;

    private int posSel1;
    private int posSel2;

    void Start(){
        posSel1 = 1;
        posSel2 = 2;
        selector1.transform.position = pos[posSel1].position;
        selector2.transform.position = pos[posSel2].position;        
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.D)){
            if (posSel1<3)
                posSel1++;
            else
                posSel1=0;
            selector1.transform.position = pos[posSel1].position;

        }
        else if(Input.GetKeyDown(KeyCode.A)){
            if (posSel1>0)
                posSel1--;
            else
                posSel1=3;
            selector1.transform.position = pos[posSel1].position;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            if (posSel2<3)
                posSel2++;
            else
                posSel2=0;
            selector2.transform.position = pos[posSel2].position;

        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if (posSel2>0)
                posSel2--;
            else
                posSel2=3;
            selector2.transform.position = pos[posSel2].position;
        }

    }

    
}
