using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject selector1;
    public GameObject selector2;
    public Transform[] pos;

    private int posSel1;
    private int posSel2;
    private int player1Selection;
    private int player2Selection;
    private bool isPlayer1Selected;
    private bool isPlayer2Selected;

    private GameManager gm;
    void Start(){
        gm = GameManager.Instance;
        posSel1 = 1;
        posSel2 = 2;
        selector1.transform.position = pos[posSel1].position;
        selector2.transform.position = pos[posSel2].position; 
               
        
    }

    void Update(){

        if(isPlayer1Selected && isPlayer2Selected){
            gm.ChangeCurrentMode(GameManager.GameMode.Vs);
            SceneManager.LoadScene("1vs1GameScene");        
        }
        if(player1Selection==0){
            if(Input.GetKeyDown(KeyCode.Return)){
                gm.SetPlayer1Number(posSel1);
                isPlayer1Selected = true;
                Debug.Log("Player 1 selected");                
            }
            else{
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
            }
        }

        if(player2Selection == 0){
            if(Input.GetKeyDown(KeyCode.KeypadEnter)){
                gm.SetPlayer2Number(posSel2);
                isPlayer2Selected = true;
                Debug.Log("Player 2 selected");
            }
            else{
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

    }

    
}
