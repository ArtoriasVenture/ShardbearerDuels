using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public enum BattleState { START, ROUNDSTARTP1,ROUNDSTARTP2, PLAYER1TURN, PLAYER2TURN, END }

public class BattleSystem : MonoBehaviour
{

public GameObject player1Prefab;
public GameObject player2Prefab;

public Transform player1Station;
public Transform player2Station;

PlayerStatsFinal player1;
PlayerStatsFinal player2;

public Text dialogueText;

public BattleHUD player1HUD;
public BattleHUD player2HUD;

public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        GameObject player1GO = Instantiate(player1Prefab, player1Station);
        player1 = player1GO.GetComponent<PlayerStatsFinal>();
        
        GameObject player2GO =Instantiate(player2Prefab, player2Station);
        player2 = player2GO.GetComponent<PlayerStatsFinal>();

        //dialogueText.text = getStance();
        player1.setPosition(2);
        player2.setPosition(4);

        player1HUD.SetHUD(player1);
        player2HUD.SetHUD(player2);

        yield return new WaitForSeconds(2f);

        state = BattleState.ROUNDSTARTP1;
        RoundStartPlayer1();
        state = BattleState.ROUNDSTARTP2;
        RoundStartPlayer2();
    }

    void RoundStartPlayer1()
    {
        if (state == BattleState.ROUNDSTARTP1)
        {
        dialogueText.text = "Player 1 Choose your stance:  <br>1 = flamestance <br>2 = ironstance <br>3 = smokestance <br>4 = stonestance <br>5 = vinestance <br>6 = windstance ";           
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                player1.setStance("flame");
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                player1.setStance("iron");
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                player1.setStance("smoke");
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                player1.setStance("stone");
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                player1.setStance("vine");
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                player1.setStance("wind");
            }
            else{
                RoundStartPlayer1();
            }
        }
    }
    
    void RoundStartPlayer2()
    {
        if (state == BattleState.ROUNDSTARTP2)
        {
        dialogueText.text = "Player 2 Choose your stance:  <br>1 = flamestance <br>2 = ironstance <br>3 = smokestance <br>4 = stonestance <br>5 = vinestance <br>6 = windstance ";           
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                player2.setStance("flame");
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                player2.setStance("iron");
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                player2.setStance("smoke");
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                player2.setStance("stone");
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                player2.setStance("vine");
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                player2.setStance("wind");
            }
            else{
                RoundStartPlayer2();
            }
        }
    }
    //currently adding the gameplay loop
    //round start is done now I need to make the turn loop
    //this will be each player getting 2 turns befoer the round start is called again
    //the game will go in a 
    //roundstart , turn 1 , turn 2, loop
    //my best guess at how to do this is set a "turnsTaken" int
    //at the end of every players action it goes up by 1
    //if it reahces 4 the round start thing is called
    //this loops untill hasShattered() is true


    //void Player1Turn()
    //{
    //    if (state == BattleState.PLAYER1TURN)
    //    {
        
            
            
     //       yield return new WaitForSeconds(1f);

     //       dialogueText.text = "choose and action: <br>1 = attack <br>2 = move left<br>3 = move right";
      //      if (Input.GetKeyDown(KeyCode.Keypad1))
      //      {
      //          player1.attack();
       //     }



      //  }
   // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
