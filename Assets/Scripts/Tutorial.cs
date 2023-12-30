using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Sprite[] sBgs;
    public Image iBg;

    public void TutorialBackButton(){
        if(iBg.sprite == sBgs[0])   
            SceneManager.LoadScene("MenuScene");
        else
            iBg.sprite = sBgs[0];
    }

    public void TutorialContinueButton(){
        if(iBg.sprite == sBgs[1]){   
            GameManager.Instance.IncreaseLevelNumber();
            SceneManager.LoadScene("MapScene");
        }
        else
            iBg.sprite = sBgs[1];
    }



}
