using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    private int roundNumber;
    public HealthController player1H;
    public HealthController player2H;

    public HUDController hud;

    private bool theresAWinner;
    

    void Start(){
        RoundControl(GameManager.Instance.GetRoundNumber());
        theresAWinner = false;
    }
    private void RoundControl(int message){
        switch(message){
            case 0:
                hud.messages[0].SetActive(true);
                break;
            case 1:
                hud.messages[1].SetActive(true);
                break;
            case 2:
                hud.messages[2].SetActive(true);
                break;
            case 3:
                hud.messages[3].SetActive(true);
                break; 
            case 4:
                hud.messages[4].SetActive(true);
                break;
        }
    }

    void Update(){
        if(hud.GetCurrentNumber() == 0 || theresAWinner)
            StartCoroutine(LoadRound());
        else
            LifeControl();
    }

    IEnumerator LoadRound(){
        if(player1H.GetCurrentHealth()>player2H.GetCurrentHealth())
            RoundControl(3);
        else 
            RoundControl(4);
        yield return new WaitForSeconds(3);
        if(roundNumber < 2){
            GameManager.Instance.IncreaseNumberOfRounds();
            SceneManager.LoadScene(3);
        }

    }
    private void LifeControl(){
        if (player1H.GetCurrentHealth() == 0 || player2H.GetCurrentHealth() == 0){
            theresAWinner = true; 
        }    
    }
}
