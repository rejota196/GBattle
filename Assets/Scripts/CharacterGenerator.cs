using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerator : MonoBehaviour
{
    public GameObject[] players;
    public Transform tPos1;
    public Transform tPos2;
    private GameManager gm;
    private GameObject player1;
    private GameObject player2;
    private CombatController ccPlayer1;
    private CombatController ccPlayer2;

    void Awake(){
        gm = GameManager.Instance;
        CreatePlayer1();
        CreatePlayer2();        
        SetEnemyLayer();
    }

    private void CreatePlayer1(){
        
        player1 = Instantiate(players[gm.GetPlayer1Number()]);
        player1.name = "Player1";
        player1.transform.position = tPos1.position;
        player1.GetComponent<CharacterController>().SetControl1();
        player1.GetComponent<HealthController>().lifeBar = GameObject.Find("Character Bar 1").transform.Find("health").GetComponent<Image>();        
        player1.layer = 9;
    }

    private void CreatePlayer2(){
        player2 = Instantiate(players[gm.GetPlayer2Number()]);
        player2.name = "Player2";
        player2.transform.position = tPos2.position;
        player2.GetComponent<CharacterController>().SetControl2();
        player2.GetComponent<HealthController>().lifeBar = GameObject.Find("Character Bar 2").transform.Find("health").GetComponent<Image>();         
        player2.layer = 10;
    }

    private void SetEnemyLayer(){
        player1.GetComponent<CombatController>().SetEnemyLayer(LayerMask.GetMask(LayerMask.LayerToName(player2.layer)));
        player2.GetComponent<CombatController>().SetEnemyLayer(LayerMask.GetMask(LayerMask.LayerToName(player1.layer)));
    }
}
