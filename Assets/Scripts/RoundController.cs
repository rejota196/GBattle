using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private HealthController player1H;
    [SerializeField]
    private HealthController player2H;

    public HUDController hud;

    private bool theresAWinner;

    public GameObject[] enemies;

    private GameManager gm;
    private bool player1Win;
    private bool player2Win;

    void Start(){
        gm = GameManager.Instance;
        theresAWinner = false;
        player1Win = false;
        player2Win = false;
        RoundControl(gm.GetRoundNumber());       
        player1H = GameObject.Find("Player1").GetComponent<HealthController>();
        if(gm.GetCurrentMode() == GameManager.GameMode.Vs)
            player2H = GameObject.Find("Player2").GetComponent<HealthController>();            
        else
            EnemyInRoundControl();
    }

    private void EnemyInRoundControl(){
        int levelNumber = gm.GetLevelNumber();
        switch(levelNumber){
            case 1:
                enemies[1].SetActive(true);
                SetPlayer2HealthController(enemies[1]);
                break;
            case 2:
                enemies[2].SetActive(true);
                SetPlayer2HealthController(enemies[2]);
                break;
            case 3:
                enemies[0].SetActive(true);
                SetPlayer2HealthController(enemies[0]);
                break;
        }
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
        if(theresAWinner || hud.GetCurrentTime() == 0)
            StartCoroutine(LoadRound());
        else
            LifeControl();
    }

    IEnumerator LoadRound(){
        if(player1H.GetCurrentHealth()>player2H.GetCurrentHealth()){
            RoundControl(3);
            player1Win = true;
        }
        else{ 
            RoundControl(4);          
            player2Win = true;
        }
        
        yield return new WaitForSeconds(3);
        if(player1Win)
            gm.IncreaseRoundWonPlayer1();
        else
            gm.IncreaseRoundWonPlayer2();        

        if(gm.GetCurrentMode() == GameManager.GameMode.History){
            if(gm.GetRoundNumber() < 1 || (gm.GetRoundWonPlayer1()==1 && gm.GetRoundWonPlayer2()==1)){
                gm.IncreaseNumberOfRounds();
                SceneManager.LoadScene("GameScene");
            }
            else{
                if(gm.GetRoundWonPlayer1()>1){
                    if (gm.GetLevelNumber()>2){
                        ResetRoundValues();
                        gm.ResetLevelNumber();
                        gm.ChangeState(GameManager.GameState.Final);
                        SceneManager.LoadScene("FinalScene");
                    }
                    else{
                        ResetRoundValues();            
                        gm.IncreaseLevelNumber();            
                        SceneManager.LoadScene("MapScene");
                    } 
                }
                else{
                    ResetRoundValues();
                    SceneManager.LoadScene("TryAgainScene");
                }
                
            }
        }
        else{
            if(gm.GetRoundNumber() < 1 || (gm.GetRoundWonPlayer1()==1 && gm.GetRoundWonPlayer2()==1)){
                gm.IncreaseNumberOfRounds();
                SceneManager.LoadScene("1vs1GameScene");
            }
            else{
                ResetRoundValues();
                SceneManager.LoadScene("1v1Scene");
            }
        }

    }

    public void ResetRoundValues(){
        gm.ResetRoundNumber();
        gm.resetRoundWonPlayer1();
        gm.resetRoundWonPlayer2();
    }
    
    private void LifeControl(){
        if (player1H.GetCurrentHealth() == 0 || player2H.GetCurrentHealth() == 0)
            theresAWinner = true;
    }

    private void SetPlayer2HealthController(GameObject player2){
        player2H = player2.GetComponent<HealthController>();
    }
}
