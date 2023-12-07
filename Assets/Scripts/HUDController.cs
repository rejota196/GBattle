using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    private int currentNumber = 99;
    private int roundNumber;
    public float timeBetweenNumbers = 1f;
    public Text timeText;

    public GameObject[] messages;
    void Start(){
        RoundControl();
        StartCoroutine(TimeControl());        
    }

    private void RoundControl(){
        roundNumber = GameManager.Instance.GetRoundNumber();
        switch(roundNumber){
            case 0:
                messages[0].SetActive(true);
                break;
            case 1:
                messages[1].SetActive(true);
                break;
            case 3:
                messages[3].SetActive(true);
                break; 
        }
    }

    IEnumerator TimeControl(){
        yield return new WaitForSeconds(1.5f);
        while (GameManager.Instance.GetCurrentState() == GameManager.GameState.Playing){
            yield return new WaitForSeconds(timeBetweenNumbers);
            currentNumber-=1;
            UpdateGameTime();
        }
    }

    IEnumerator LoadRound(){
        yield return new WaitForSeconds(3);
        if(roundNumber < 1){
            GameManager.Instance.IncreaseNumberOfRounds();
            SceneManager.LoadScene(0);
        }

    }

    public void UpdateGameTime(){
        if(currentNumber < 10) {
            if(!(currentNumber < 0))
                timeText.text = "0"+currentNumber;
            else
                StartCoroutine(LoadRound());            
        }            
        else
            timeText.text = currentNumber.ToString();
    }


}
