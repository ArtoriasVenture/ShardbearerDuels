using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, END }

public class BattleSystem : MonoBehaviour
{

public GameObject player1Prefab;
public GameObject player2Prefab;

public Transform player1Station;
public Transform player2Station;

PlayerStatsFinal player1;
PlayerStatsFinal player2;

public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        
        SetupBattle();

    }

    void SetupBattle()
    {
        GameObject player1GO = Instantiate(player1Prefab, player1Station);
        player1 = player1GO.GetComponent<PlayerStatsFinal>();
        
        GameObject player2GO =Instantiate(player2Prefab, player2Station);
        player2 = player2GO.GetComponent<PlayerStatsFinal>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
