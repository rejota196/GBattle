using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int player1Number;
    private int player2Number;

    private int roundNumber;
    private int roundWonPlayer1;
    private int roundWonPlayer2;
    private int levelNumber;

    

    public enum GameMode{
        History,
        Vs
    }

    public enum GameState
    {
        Menu,
        Card,
        Playing,
        Paused,
        Final
    }

    [SerializeField]
    private GameMode currentMode;

    [SerializeField]
    private GameState currentState;

    public int stage;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public void ChangeState(GameState newState)
    {
        currentState = newState;       
    }

    public void ChangeCurrentMode(GameMode newMode){
        currentMode = newMode;
    }

    public GameState GetCurrentState(){
        return currentState;
    }

    public GameMode GetCurrentMode(){
        return currentMode;
    }

    public void IncreaseNumberOfRounds(){
        roundNumber++;
    }

    public int GetRoundNumber(){
        return roundNumber;
    }

    public void ResetRoundNumber(){
        roundNumber = 0;
    }

    public void IncreaseRoundWonPlayer1(){
        roundWonPlayer1++;
    }
    public void IncreaseRoundWonPlayer2(){
        roundWonPlayer2++;
    }
    public int GetRoundWonPlayer1(){
        return roundWonPlayer1;
    }
    public int GetRoundWonPlayer2(){
        return roundWonPlayer2;
    }
    public void resetRoundWonPlayer1(){
        roundWonPlayer1 = 0;
    }

    public void resetRoundWonPlayer2(){
        roundWonPlayer2 = 0;
    }

    public void IncreaseLevelNumber(){
        levelNumber++;
    }

    public int GetLevelNumber(){
        return levelNumber;
    }
    public void ResetLevelNumber(){
        levelNumber = 0; 
    }

    public void SetPlayer1Number(int playerNumber){
        player1Number = playerNumber;
    }
    public void SetPlayer2Number(int playerNumber){
        player2Number = playerNumber;
    }

    public int GetPlayer1Number(){
        return player1Number;
    }
    public int GetPlayer2Number(){
        return player2Number;
    }

}
