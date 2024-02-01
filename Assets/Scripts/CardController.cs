using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    private float waitTime;
    private Animator anim;

    private GameManager gm;
    void Start(){
        gm = GameManager.Instance;
        int gameLevel = gm.GetLevelNumber();
        anim = GetComponent<Animator>();
        switch(gameLevel){
            case 1:
                anim.SetFloat("level", 0);
                waitTime = 58;
                break;
            case 2:
                anim.SetFloat("level", 0.5f);
                waitTime = 83.1f;
                break;
            case 3:
                anim.SetFloat("level", 1);
                waitTime = 63;
                break;
        }
        StartCoroutine(WaitForCard());
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            gm.stage++;
            SceneManager.LoadScene(sceneNumber+1);
        }

    }

    IEnumerator WaitForCard(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(waitTime);
        gm.stage++;
        SceneManager.LoadScene(sceneNumber+1);
    }
}
