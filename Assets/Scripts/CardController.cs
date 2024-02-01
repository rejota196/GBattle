using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    private float waitTime;
    private Animator anim;

    private GameManager gm;
    public AudioSource audio;
    public AudioClip[] audioClips;
    void Start(){
        gm = GameManager.Instance;
        int gameLevel = gm.GetLevelNumber();
        anim = GetComponent<Animator>();
        switch(gameLevel){
            case 1:
                anim.SetFloat("level", 0);
                waitTime = 66;
                audio.clip = audioClips[0];
                break;
            case 2:
                anim.SetFloat("level", 0.5f);
                waitTime = 69f;
                audio.clip = audioClips[1];
                break;
            case 3:
                anim.SetFloat("level", 1);
                audio.clip = audioClips[2];
                waitTime = 52;
                break;
        }
        audio.Play();
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
