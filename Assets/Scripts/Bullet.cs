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
                transform.Translate(direction*speed*Time.deltaTime);
                lifeTime+= Time.deltaTime;        
            }
            else{
                Destroy(gameObject);
            }
        }        
    }

    public void SetDirection(Vector3 direction){
        this.direction = direction;
        if (direction.x>0)
            transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        else
            transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Player1"){
            other.gameObject.GetComponent<HealthController>().TakeDamage(10);
            GameObject burst = Instantiate(burstGO, transform.position,Quaternion.identity);
            Destroy(gameObject);
            
        }
    }    
}
