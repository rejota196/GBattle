using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button : MonoBehaviour
{

    private GameManager gm;
    private RoundController rc;
    private Tutorial tuto;
    private HUDController hud;

    public GameObject responsePanel;
        
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
            case 4:
                GameObject canvas = GameObject.Find("Canvas");
                GameObject achievementMenu = GetAchievementMenu(canvas);
                achievementMenu.SetActive(true);
                Debug.Log("Open Achievement panel");
                break;

        }
    }

    private GameObject GetAchievementMenu(GameObject canvas){
        GameObject achievementMenu = new GameObject();
        Transform[] allTransforms = canvas.GetComponentsInChildren<Transform>(true);

        foreach (Transform transform in allTransforms)
        {
            Debug.Log(transform.name);
            if (!transform.gameObject.activeSelf && transform.name=="AchievementsPanel")
            {
                achievementMenu = transform.gameObject;
                break;
            }
        }

        return achievementMenu;
    }

    public void ClickTryAgain(){
        SceneManager.LoadScene("MapScene");
    }

    public void SkipCardScene(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
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

    public void CloseAchievementsPanel(GameObject achievementsMenu){
        achievementsMenu.SetActive(false);
    }
    public void ShowAchievement(GameObject achievement){
        Debug.Log("Open Achievement");
        achievement.SetActive(true);
    }
    public void ShowAchievementsMenu(GameObject achievement){
        achievement.SetActive(false);
    }

    public void ClickOnTriviaOption(){
        hud = FindObjectOfType<HUDController>();
        string answerSelected = GetComponent<Text>().text;
        string currentAnswer = hud.GetCurrentQuestion()[5];
        if (currentAnswer.Contains(answerSelected)){
            hud.truthValue.text = "Correcto";
            hud.truthValue.color = new Color(0.0f, 1.0f, 0.0f);
        }
        else{
            hud.truthValue.text = "Incorrecto";
            hud.truthValue.color = new Color(1.0f,0.0f,0.0f);
        }

        responsePanel.SetActive(true);        
    }

    public void DeactivatedTrivia(){
        hud = GameObject.Find("HUDController").GetComponent<HUDController>();
        gm.ChangeState(GameManager.GameState.Playing);
        hud.StartFight();
        hud.DeactivatedTrivia();

        
    }

    
}
