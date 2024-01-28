using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;



public class HUDController : MonoBehaviour
{
    private int currentNumber = 99;
    public float timeBetweenNumbers = 1f;
    public Text timeText;

    public Image panelImage;
    public Sprite[] bgs;
    public GameObject[] names;

    public GameObject[] messages;
    public GameObject trivia;
    public GameObject responsePanel;
    public GameObject achievementPanel;
    public QuestionDB question;
    public Text triviaQuestion;
    public Text triviaOption1;
    public Text triviaOption2;
    public Text triviaOption3;
    public Text triviaOption4;
    public Text triviaCorrectAnswer;
    public Text triviaDescriptionResponse;
    public Text truthValue;
    private string[] currentQuestion;
    
    
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

        UpdateTrivia();
        ActivateTrivia();
        GameManager.Instance.ChangeState(GameManager.GameState.Paused);                
    }

    private void UpdateTrivia(){
        int questionNumber = (int)(Random.Range(1,question.GetQuestionCount()+1));
        Debug.Log(questionNumber);
        currentQuestion = question.GetQuestionById(questionNumber);
        triviaQuestion.text = currentQuestion[0];
        triviaOption1.text = currentQuestion[1];
        triviaOption2.text = currentQuestion[2];
        triviaOption3.text = currentQuestion[3];
        triviaOption4.text = currentQuestion[4];
        triviaCorrectAnswer.text = currentQuestion[5];
        triviaDescriptionResponse.text = currentQuestion[6];
        
    }
    public void ActivateTrivia(){
        trivia.SetActive(true);        
    }
    public void DeactivatedTrivia(){
        trivia.SetActive(false);
    }

    IEnumerator TimeControl(){
        while(GameManager.Instance.GetCurrentState()==GameManager.GameState.Playing){
            yield return new WaitForSeconds(timeBetweenNumbers);
            currentNumber-=1;
            UpdateGameTime();
        }
               
    }
    public void StartFight(){
        StartCoroutine(TimeControl());
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
    public string[] GetCurrentQuestion(){
        return currentQuestion;
    }

    


}
