using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public int buttonNumber;

    public void Click(){
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
}
