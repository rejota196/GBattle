using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapAnimations : MonoBehaviour
{
    void Start(){
        GameManager.Instance.ChangeState(GameManager.GameState.Card);
        SceneManager.LoadScene("CardScene");
    }   
}
