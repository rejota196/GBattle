using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPauseController : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject bVolume;
    public Image iVolume;
    public Sprite[] spVolume;

    private GameManager gm;
    

    void Start(){
        gm = GameManager.Instance;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
            if(menuPause.activeInHierarchy){
                gm.ChangeState(GameManager.GameState.Playing);
                Time.timeScale = 1;
                menuPause.SetActive(false);
            }
            else{
                gm.ChangeState(GameManager.GameState.Paused);
                Time.timeScale = 0;
                menuPause.SetActive(true);
            }

    }

    public void ADVolumeControl(){
        bVolume.SetActive(!bVolume.activeInHierarchy);
    }
    public void UpdateImageVolume(float value){
        if (value != 0)
            iVolume.sprite = spVolume[0]; 
        else
            iVolume.sprite = spVolume[1];
    }


}
