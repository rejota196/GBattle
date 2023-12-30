using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{

    private GameManager gm;
    private RoundController rc;
    private Tutorial tuto;    
    void Start(){
        gm = GameManager.Instance;
    }
    public void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene("MenuScene");
    }
    public void ReturnToMainMenuInGame(){
        rc = FindObjectOfType<RoundController>();
        if (rc != null)
            rc.ResetRoundValues();
        Time.timeScale = 1;                
        gm.ResetLevelNumber();
        SceneManager.LoadScene("MenuScene");
    }

    public void ClickOnMenuOption(int buttonNumber){
        switch(buttonNumber){
            case 1:
                Debug.Log("Load Story Mode");
                SceneManager.LoadScene("Tutorial");
                break;
            case 2:
                Debug.Log("1 vs 1");
                SceneManager.LoadScene("1v1Scene");
                break;
            case 3:
                Debug.Log("Credits");
                SceneManager.LoadScene("CreditsScene");
                break;
        }
    }

    public void ClickTryAgain(){
        SceneManager.LoadScene("MapScene");
    }

    public void SkipCardScene(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        gm.ChangeState(GameManager.GameState.Playing);
        SceneManager.LoadScene(sceneNumber+1);
    }

    public void Volume(){
        MenuPauseController pauseController = GameObject.FindObjectOfType<MenuPauseController>();
        pauseController.ADVolumeControl();
    }

    public void TutorialBackButton(){
        tuto = FindObjectOfType<Tutorial>();
        if(tuto!= null)
            tuto.TutorialBackButton();
    }

    public void TutorialContinueButton(){
        tuto = FindObjectOfType<Tutorial>();
        if(tuto!= null)
            tuto.TutorialContinueButton();
    }

    
}
