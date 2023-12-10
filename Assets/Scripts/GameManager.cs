using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int roundNumber;
    private int roundWonPlayer1;
    private int roundWonPlayer2;
    private int levelNumber;

    public enum GameState
    {
        Menu,
        Card,
        Playing,
        Paused,
        Final
    }

    [SerializeField]
    private GameState currentState;

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

        switch (currentState)
        {
            case GameState.Menu:
                break;
            case GameState.Playing:
                break;
            case GameState.Final:
                break;
        }
    }

    public GameState GetCurrentState(){
        return currentState;
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


}
