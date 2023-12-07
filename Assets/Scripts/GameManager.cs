using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int roundNumber;

    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver
    }

    [SerializeField]
    private GameState currentState = GameState.Menu;

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

    private void Start()
    {
        ChangeState(GameState.Playing);
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


}
