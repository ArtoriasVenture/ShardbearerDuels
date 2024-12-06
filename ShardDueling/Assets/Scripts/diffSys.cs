using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
[SerializeField] 

public enum BattleState { START, ROUNDSTARTP1,ROUNDSTARTP2, PLAYER1TURN, PLAYER2TURN, RESOLVEACTIONS, END }

public class diffSys : MonoBehaviour
{

public GameObject player1Prefab;
public GameObject player2Prefab;

public GameObject P1StanceButtons;
public GameObject P1ActionButtons;

public GameObject P2StanceButtons;
public GameObject P2ActionButtons;

public Transform player1Station;
public Transform player2Station;

PlayerStatsFinal player1;
PlayerStatsFinal player2;

public TextMeshProUGUI dialogueText;

string ActionP1 = "";
string ActionP2 = "";

public BattleHUD player1HUD;
public BattleHUD player2HUD;

int roundTracker = 0;

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
        player1.setName("player1");

        GameObject player2GO =Instantiate(player2Prefab, player2Station);
        player2 = player2GO.GetComponent<PlayerStatsFinal>();
        player2.setName("player2");

        
        dialogueText.text = "Duel Start!";
        player1.setPosition(2);
        player2.setPosition(4);

        player1HUD.SetHUD(player1);
        player2HUD.SetHUD(player2);

        yield return new WaitForSeconds(2f);

            state = BattleState.ROUNDSTARTP1;
            StartCoroutine(RoundStartPlayer1());
        
    }

    IEnumerator RoundStartPlayer1()
    {
        if (state == BattleState.ROUNDSTARTP1)
        {          
        dialogueText.text ="Player 1 Choose your stance:" ;  
        yield return new WaitForSeconds(1f);           
        P1StanceButtons.gameObject.SetActive(true);

            
        
        }
    }
    
    IEnumerator RoundStartPlayer2()
    {
        if (state == BattleState.ROUNDSTARTP2)
        {
            dialogueText.text = "Player 2 Choose your stance: ";           
            yield return new WaitForSeconds(1f);           
            P2StanceButtons.gameObject.SetActive(true);
        }
    }


    IEnumerator getP1Action()
    {
        if (state == BattleState.PLAYER1TURN)
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "player 1 choose an action: ";
            P1ActionButtons.gameObject.SetActive(true);
        }
    }

    IEnumerator getP2Action()
    {
        if (state == BattleState.PLAYER2TURN)
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "player 2 choose an action: ";
            P2ActionButtons.gameObject.SetActive(true);
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
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    }
                    yield return new WaitForSeconds(2f);
                    player1.attack(player2);
                    player2HUD.SetHP(player2);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    }
                }
                else 
                {
                    player1.attack(player2);
                    player2HUD.SetHP(player2);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    } 
                    yield return new WaitForSeconds(2f);
                    player2.attack(player1);
                    player1HUD.SetHP(player1);
                    if ((player1.hasShattered() || player2.hasShattered())  == true)
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    }
                }
            roundTracker ++;
            if (roundTracker == 2)
            {
                state = BattleState.ROUNDSTARTP1;
                StartCoroutine(RoundStartPlayer1());
            }
            else 
            {
                state = BattleState.PLAYER1TURN;
                StartCoroutine(getP1Action());
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
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    }
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
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    }
                }
            roundTracker ++;
            if (roundTracker == 2)
            {
                state = BattleState.ROUNDSTARTP1;
                StartCoroutine(RoundStartPlayer1());
            }
            else 
            {
                state = BattleState.PLAYER1TURN;
                StartCoroutine(getP1Action());
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
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    } 
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
                    {
                        state = BattleState.END; 
                        StartCoroutine(gameOver());   
                    }
                        
                }
            roundTracker ++;
            if (roundTracker == 2)
            {
                state = BattleState.ROUNDSTARTP1;
                StartCoroutine(RoundStartPlayer1());
            }
            else 
            {
                state = BattleState.PLAYER1TURN;
                StartCoroutine(getP1Action());
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
            roundTracker ++;
            if (roundTracker == 2)
            {
                state = BattleState.ROUNDSTARTP1;
                StartCoroutine(RoundStartPlayer1());
            }
            else 
            {
                state = BattleState.PLAYER1TURN;
                StartCoroutine(getP1Action());
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

    //action buttons
    public void OnP1sAttackButton()
    {
        ActionP1 = "attack";
        state = BattleState.PLAYER2TURN;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP2Action());
    }
    public void OnP2sAttackButton()
    {
        ActionP2 = "attack";
        state = BattleState.RESOLVEACTIONS;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(playoutActions());
    }
    public void OnP1sMLButton()
    {
        ActionP1 = "move left";
        state = BattleState.PLAYER2TURN;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP2Action());
    }
    public void OnP2sMLButton()
    {
        ActionP2 = "move left";
        state = BattleState.RESOLVEACTIONS;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(playoutActions());
    }
    public void OnP1sMRButton()
    {
        ActionP1 = "move right";
        state = BattleState.PLAYER2TURN;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP2Action());
    }
    public void OnP2sMRButton()
    {
        ActionP2 = "move right";
        state = BattleState.RESOLVEACTIONS;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(playoutActions());
    }

    // set stance buttons 
    public void OnP1sFlameButton()
    {
        player1.setStance("flame");
        player1HUD.SetHUD(player1);
        state = BattleState.ROUNDSTARTP2;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(RoundStartPlayer2());
    }
    public void OnP2sFlameButton()
    {
        player2.setStance("flame");
        player2HUD.SetHUD(player2);
        state = BattleState.PLAYER1TURN;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP1Action());
    
    }
    public void OnP1sSmokeButton()
    {
        player1.setStance("smoke");
        player1HUD.SetHUD(player1);
        state = BattleState.ROUNDSTARTP2;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(RoundStartPlayer2());
    }
    public void OnP2sSmokeButton()
    {
        player2.setStance("smoke");
         player2HUD.SetHUD(player2);
        state = BattleState.PLAYER1TURN;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP1Action());
    }
    public void OnP1sVineButton()
    {
        player1.setStance("vine");
        player1HUD.SetHUD(player1);
        state = BattleState.ROUNDSTARTP2;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(RoundStartPlayer2());
    }
    public void OnP2sVineButton()
    {
        player2.setStance("vine");
         player2HUD.SetHUD(player2);
        state = BattleState.PLAYER1TURN;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP1Action());
    }
    public void OnP1sWindButton()
    {
        player1.setStance("wind");
        player1HUD.SetHUD(player1);
        state = BattleState.ROUNDSTARTP2;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(RoundStartPlayer2());
    }
    public void OnP2sWindButton()
    {
        player2.setStance("wind");
         player2HUD.SetHUD(player2);
        state = BattleState.PLAYER1TURN;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP1Action());
    }
    public void OnP1sIronButton()
    {
        player1.setStance("iron");
        player1HUD.SetHUD(player1);
        state = BattleState.ROUNDSTARTP2;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(RoundStartPlayer2());
    }
    public void OnP2sIronButton()
    {
        player2.setStance("iron");
         player2HUD.SetHUD(player2);
        state = BattleState.PLAYER1TURN;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP1Action());
    }
    public void OnP1sStoneButton()
    {
        player1.setStance("stone");
        player1HUD.SetHUD(player1);
        state = BattleState.ROUNDSTARTP2;
        P1ActionButtons.gameObject.SetActive(false);
        StartCoroutine(RoundStartPlayer2());
    }
    public void OnP2sStoneButton()
    {
        player2.setStance("stone");
         player2HUD.SetHUD(player2);
        state = BattleState.PLAYER1TURN;
        P2ActionButtons.gameObject.SetActive(false);
        StartCoroutine(getP1Action());
    }

}

