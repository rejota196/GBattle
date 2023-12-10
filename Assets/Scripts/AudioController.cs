using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] clips;

    void Start(){
        audio = GetComponent<AudioSource>();
    }
    
    public void Attack(){
        audio.PlayOneShot(clips[0]);
    }

    public void Jump(){
        audio.PlayOneShot(clips[1]);
    }

    public void Die(){
        audio.PlayOneShot(clips[2]);
    }
}
