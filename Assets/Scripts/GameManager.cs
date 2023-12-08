using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int roundNumber;
    private int levelNumber;

    public enum GameState
    {
        Menu,
        Card,
        Playing,
        Paused,
        GameOver
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
            case GameState.GameOver:
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

    public void IncreaseLevelNumber(){
        levelNumber++;
    }

    public int GetLevelNumber(){
        return levelNumber;
    }


}
