using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;



public class HUDController : MonoBehaviour
{
    private int currentNumber = 99;
    public float timeBetweenNumbers = 1f;
    public Text timeText;

    public Image panelImage;
    public Sprite[] bgs;
    public GameObject[] names;

    public GameObject[] messages;
    void Start(){
        switch(GameManager.Instance.GetLevelNumber()){
            case 1:
                panelImage.sprite = bgs[0];
                names[0].SetActive(true);
                break;
            case 2:
                panelImage.sprite = bgs[1];
                names[1].SetActive(true);
                break;
            case 3:
                panelImage.sprite = bgs[2];
                names[2].SetActive(true);
                break;

        }
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

    public int GetCurrentTime(){
        return currentNumber;
    }

    


}
