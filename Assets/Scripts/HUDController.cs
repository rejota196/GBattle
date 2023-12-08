using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class HUDController : MonoBehaviour
{
    private int currentNumber = 5;
    public float timeBetweenNumbers = 1f;
    public Text timeText;

    public GameObject[] messages;
    void Start(){
        StartCoroutine(TimeControl());        
    }

    

    IEnumerator TimeControl(){
        yield return new WaitForSeconds(1.5f);
        while (GameManager.Instance.GetCurrentState() == GameManager.GameState.Playing){
            yield return new WaitForSeconds(timeBetweenNumbers);
            currentNumber-=1;
            UpdateGameTime();
        }
    }

    public void UpdateGameTime(){
        if(currentNumber < 10) {
            if(!(currentNumber < 0))
                timeText.text = "0"+currentNumber;                        
        }            
        else
            timeText.text = currentNumber.ToString();
    }

    public int GetCurrentNumber(){
        return currentNumber;
    }


}
