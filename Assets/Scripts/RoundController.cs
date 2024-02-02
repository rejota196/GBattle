using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private HealthController player1H;
    [SerializeField]
    private HealthController player2H1;
    [SerializeField]
    private HealthController player2H2;
    [SerializeField]
    private HealthController player2H3;

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
            player2H1 = GameObject.Find("Player2").GetComponent<HealthController>();            
        else
            EnemyInRoundControl();
    }

    private void EnemyInRoundControl(){
        int levelNumber = gm.GetLevelNumber();
        if(gm.stage == 1){
            switch(levelNumber){
                case 1:
                    enemies[1].SetActive(true);
                    SetPlayer2HealthControllerS1(enemies[1]);
                    break;
                case 2:
                    enemies[2].SetActive(true);
                    SetPlayer2HealthControllerS1(enemies[2]);
                    break;
                case 3:
                    enemies[0].SetActive(true);
                    SetPlayer2HealthControllerS1(enemies[0]);
                    break;
            }
        }
        else if(gm.stage == 2){
            switch(levelNumber){
                case 1:
                    enemies[1].SetActive(true);
                    enemies[5].SetActive(true);
                    SetPlayer2HealthControllerS2(enemies[1], enemies[5]);
                    break;
                case 2:
                    enemies[2].SetActive(true);
                    enemies[7].SetActive(true);
                    SetPlayer2HealthControllerS2(enemies[2], enemies[7]);
                    break;
                case 3:
                    enemies[0].SetActive(true);
                    enemies[3].SetActive(true);
                    SetPlayer2HealthControllerS2(enemies[0], enemies[3]);
                    break;
            }
        }
        else{
            switch(levelNumber){
                case 1:
                    enemies[1].SetActive(true);
                    enemies[5].SetActive(true);
                    enemies[6].SetActive(true);
                    SetPlayer2HealthControllerS3(enemies[1], enemies[5], enemies[6]);
                    break;
                case 2:
                    enemies[2].SetActive(true);
                    enemies[7].SetActive(true);
                    enemies[8].SetActive(true);
                    SetPlayer2HealthControllerS3(enemies[2], enemies[7], enemies[8]);
                    break;
                case 3:
                    enemies[0].SetActive(true);
                    enemies[3].SetActive(true);
                    enemies[4].SetActive(true);
                    SetPlayer2HealthControllerS3(enemies[0], enemies[3], enemies[4]);
                    break;
            }
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
        switch(gm.stage){
            case 0:
                LoadRoundStage1();
                break;
            case 1:
                LoadRoundStage1();
                break;
            case 2:
                LoadRoundStage2();
                break;
            case 3:
                LoadRoundStage3();
                break;
        }       
        
        yield return new WaitForSeconds(3);
        if(player1Win)
            gm.IncreaseRoundWonPlayer1();
        else
            gm.IncreaseRoundWonPlayer2();        

        if(gm.GetCurrentMode() == GameManager.GameMode.History){
            if(gm.GetRoundNumber() < 1 || (gm.GetRoundWonPlayer1()==1 && gm.GetRoundWonPlayer2()==1)){
                gm.IncreaseNumberOfRounds();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else{
                if(gm.GetRoundWonPlayer1()>1){
                    if (gm.GetLevelNumber()>2 && gm.stage>2){
                        ResetRoundValues();
                        gm.ResetLevelNumber();
                        gm.ChangeState(GameManager.GameState.Final);
                        SceneManager.LoadScene("FinalScene");
                    }
                    else{
                        ResetRoundValues();
                        if(gm.stage>2){
                            gm.IncreaseLevelNumber(); 
                            gm.stage = 0;           
                            SceneManager.LoadScene("MapScene");
                        }
                        else{
                            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
                            gm.stage++;
                            SceneManager.LoadScene(sceneNumber+1);
                        }            
                        
                    } 
                }
                else{
                    ResetRoundValues();
                    gm.stage = 0;
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

    private void LoadRoundStage1(){
        if(player1H.GetCurrentHealth()>player2H1.GetCurrentHealth()){
            RoundControl(3);
            player1Win = true;
        }
        else{ 
            RoundControl(4);          
            player2Win = true;
        }
    }
    private void LoadRoundStage2(){
        if(player1H.GetCurrentHealth()>(player2H1.GetCurrentHealth()+player2H2.GetCurrentHealth())){
            RoundControl(3);
            player1Win = true;
        }
        else{ 
            RoundControl(4);          
            player2Win = true;
        }
    }
    private void LoadRoundStage3(){
        if(player1H.GetCurrentHealth()>(player2H1.GetCurrentHealth()+player2H2.GetCurrentHealth()+player2H3.GetCurrentHealth())){
            RoundControl(3);
            player1Win = true;
        }
        else{ 
            RoundControl(4);          
            player2Win = true;
        }
    }

    public void ResetRoundValues(){
        gm.ResetRoundNumber();
        gm.resetRoundWonPlayer1();
        gm.resetRoundWonPlayer2();
    }
    
    private void LifeControl(){
        switch(gm.stage){
            case 0:
                if (player1H.GetCurrentHealth() == 0 || player2H1.GetCurrentHealth() == 0)
                    theresAWinner = true;
                break;
            case 1:
                if (player1H.GetCurrentHealth() == 0 || player2H1.GetCurrentHealth() == 0)
                    theresAWinner = true;
                break;
            case 2:
                if (player1H.GetCurrentHealth() == 0 || (player2H1.GetCurrentHealth() == 0 && player2H2.GetCurrentHealth() == 0))
                    theresAWinner = true;
                break;
            case 3:
                if (player1H.GetCurrentHealth() == 0 || (player2H1.GetCurrentHealth() == 0 && player2H2.GetCurrentHealth() == 0) && player2H3.GetCurrentHealth() == 0)
                    theresAWinner = true;
                break;

        }
    }

    private void SetPlayer2HealthControllerS1(GameObject player2){
        player2H1 = player2.GetComponent<HealthController>();
    }
    private void SetPlayer2HealthControllerS2(GameObject player2_1, GameObject player2_2){
        player2H1 = player2_1.GetComponent<HealthController>();
        player2H2 = player2_2.GetComponent<HealthController>();
    }
    private void SetPlayer2HealthControllerS3(GameObject player2, GameObject player2_2, GameObject player2_3){
        player2H1 = player2.GetComponent<HealthController>();
        player2H2 = player2_2.GetComponent<HealthController>();
        player2H3 = player2_3.GetComponent<HealthController>();
    }
}
