using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
[SerializeField] 

    public enum BattleState { START, ROUNDSTARTP1,ROUNDSTARTP2, PLAYER1TURN, PLAYER2TURN, RESOLVEACTIONS, END }

public class BattleSystem : MonoBehaviour
{

public GameObject player1Prefab;
public GameObject player2Prefab;

public Transform player1Station;
public Transform player2Station;

PlayerStatsFinal player1;
PlayerStatsFinal player2;

public TextMeshProUGUI dialogueText;

string ActionP1 = "";
string ActionP2 = "";

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
        while ((player1.hasShattered() && player2.hasShattered())  == false)
        {
            state = BattleState.ROUNDSTARTP1;
            RoundStartPlayer1();
            state = BattleState.ROUNDSTARTP2;
            RoundStartPlayer2();
            state = BattleState.PLAYER1TURN;
            getP1Action();
            state = BattleState.PLAYER2TURN;
            getP2Action();
            state = BattleState.RESOLVEACTIONS;
            StartCoroutine(playoutActions());
            if ((player1.hasShattered() || player2.hasShattered())  == true)
            {
                    state = BattleState.END; 
                    StartCoroutine(gameOver());
            }
            else{
                state = BattleState.PLAYER1TURN;
                getP1Action();
                state = BattleState.PLAYER2TURN;
                getP2Action();
                state = BattleState.RESOLVEACTIONS;
                playoutActions();  
            }
        }
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


    void getP1Action()
    {
        if (state == BattleState.PLAYER1TURN)
        {
            //yield return new WaitForSeconds(1f);

            dialogueText.text = "choose and action: <br>1 = attack <br>2 = move left<br>3 = move right";
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                ActionP1 = "attack";
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                ActionP1 = "move left";
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                ActionP1 = "move right";
            }
            else
                getP1Action();
        }
    }

    void getP2Action()
    {
        if (state == BattleState.PLAYER2TURN)
        {
            //yield return new WaitForSeconds(1f);

            dialogueText.text = "choose and action: <br>1 = attack <br>2 = move left<br>3 = move right";
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                ActionP2 = "attack";
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                ActionP2 = "move left";
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                ActionP2 = "move right";
            }
            else
                getP2Action();
        }
    }

    IEnumerator playoutActions() 
    {   
        int actionSpeed1 = 3;
        int actionSpeed2 = 3;

        if (state == BattleState.RESOLVEACTIONS)
        {
            if ((ActionP1 == "attack") && (ActionP2 == "attack"))
            {
                actionSpeed1 = player1.getSpeed();
                actionSpeed2 = player2.getSpeed();

                if (actionSpeed1 > actionSpeed2) 
                {
                    player2.attack(player1);
                    player1HUD.SetHP(player1);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break; 
                    yield return new WaitForSeconds(2f);
                    player1.attack(player2);
                    player2HUD.SetHP(player2);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break;  
                }
                else 
                {
                    player1.attack(player2);
                    player2HUD.SetHP(player2);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break;  
                    yield return new WaitForSeconds(2f);
                    player2.attack(player1);
                    player1HUD.SetHP(player1);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break;  
                }
            }//if both attack

            if ((ActionP1 == "attack") && (ActionP2 != "attack"))
            {
                actionSpeed1 = player1.getSpeed();
                
                if  (actionSpeed1 < actionSpeed2)
                {
                    player1.attack(player2);
                    player2HUD.SetHP(player2);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break; 
                    yield return new WaitForSeconds(2f);
                    
                    if (ActionP2 == "move left")
                        player2.moveLeft();
                    if (ActionP2 == "move right")
                        player2.moveRight();
                }
                else 
                {
                    if (ActionP2 == "move left")
                        player2.moveLeft();
                    if (ActionP2 == "move right")
                        player2.moveRight();
                    
                    yield return new WaitForSeconds(2f);
                    player1.attack(player2);
                    player2HUD.SetHP(player2);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break;  
                }
            }//if p1 attack and p2 move

            if ((ActionP2 == "attack") && (ActionP1 != "attack"))
            {
                actionSpeed2 = player2.getSpeed();
                
                if  (actionSpeed2 < actionSpeed1)
                {
                    player2.attack(player1);
                    player1HUD.SetHP(player1);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break;  
                    yield return new WaitForSeconds(2f);
                    
                    if (ActionP1 == "move left")
                        player1.moveLeft();
                    if (ActionP1 == "move right")
                        player1.moveRight();
                }
                else 
                {
                    if (ActionP1 == "move left")
                        player1.moveLeft();
                    if (ActionP1 == "move right")
                        player1.moveRight();
                    
                    yield return new WaitForSeconds(2f);
                    player2.attack(player1);
                    player1HUD.SetHP(player1);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                        yield break; 
                }
            }//if p2 attack and p1 move

            if ((ActionP1 != "attack") && (ActionP2 != "attack"))
            {
                actionSpeed1 = player1.getSpeed();
                actionSpeed2 = player2.getSpeed();

                if (actionSpeed1 > actionSpeed2) 
                {
                    if (ActionP2 == "move left")
                        player2.moveLeft();
                    if (ActionP2 == "move right")
                        player2.moveRight();
                    
                    yield return new WaitForSeconds(2f);
                  
                    if (ActionP1 == "move left")
                        player1.moveLeft();
                    if (ActionP1 == "move right")
                        player1.moveRight();
                }
                else 
                {
                    if (ActionP1 == "move left")
                        player1.moveLeft();
                    if (ActionP1 == "move right")
                        player1.moveRight();
                    
                    yield return new WaitForSeconds(2f);                 
                    
                    if (ActionP2 == "move left")
                        player2.moveLeft();
                    if (ActionP2 == "move right")
                        player2.moveRight();
                }
            }//if both move

            
        }

    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(3f);
        if (player1.hasShattered() == true)
            dialogueText.text = "Player 2 has claimed victory!";
        
        if (player2.hasShattered() == true)
            dialogueText.text = "Player 2 has claimed victory!";
        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
