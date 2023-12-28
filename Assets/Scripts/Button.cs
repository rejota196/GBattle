using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void ClickOnMenuOption(int buttonNumber){
        switch(buttonNumber){
            case 1:
                Debug.Log("Load Story Mode");
                GameManager.Instance.IncreaseLevelNumber();
                SceneManager.LoadScene(GameManager.Instance.GetLevelNumber());
                break;
            case 2:
                Debug.Log("1 vs 1");
                SceneManager.LoadScene(4);
                break;
            case 3:
                Debug.Log("Credits");
                SceneManager.LoadScene(5);
                break;
        }
    }

    public void ClickTryAgain(){
        SceneManager.LoadScene(1);
    }

    public void SkipCardScene(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.ChangeState(GameManager.GameState.Playing);
        SceneManager.LoadScene(sceneNumber+1);
    }

    
}
