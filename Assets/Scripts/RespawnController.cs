using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public float respawnHeight = -7f;
    private Vector3 respawnPosition;

    void Start(){
        respawnPosition = GameObject.Find("RespawnPosition").GetComponent<Transform>().position;
    }

    void Update()
    {
        if(GameManager.Instance.GetCurrentState() == GameManager.GameState.Playing){
            if (transform.position.y < respawnHeight)        
                Respawn();        
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
    }
}
