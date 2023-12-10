using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audio;


    void Start(){
        switch(GameManager.Instance.GetLevelNumber()){
            case 1:
                audio.clip = clips[0];     
                break;
            case 2:
                audio.clip = clips[1];
                break;
            case 3:
                audio.clip = clips[2];
                break;
        }
        audio.Play();
    }
}
