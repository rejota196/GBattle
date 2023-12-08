using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    public float waitTime;
    void Start(){
        StartCoroutine(WaitForCard());
    }

    IEnumerator WaitForCard(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(waitTime);
        GameManager.Instance.ChangeState(GameManager.GameState.Playing);
        SceneManager.LoadScene(sceneNumber+1);
    }
}
