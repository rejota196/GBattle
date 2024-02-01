using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject burstGO;
    private Vector2 direction;

    private float lifeTime;
    


    void Start(){
        //direction = transform.parent.forward;        
    }

    void FixedUpdate(){
        if(direction!=null){
            if(lifeTime<2){
                transform.Translate(transform.forward*speed*Time.deltaTime);
                lifeTime+= Time.deltaTime;        
            }
            else{
                Destroy(gameObject);
            }
        }        
    }

    public void SetDirection(Vector3 direction){
        this.direction = direction;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Player1"){
            GameObject burst = Instantiate(burstGO, transform.position,Quaternion.identity);
            Destroy(gameObject);
            
        }
    }    
}
