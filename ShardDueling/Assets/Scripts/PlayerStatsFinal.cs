using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsFinal : MonoBehaviour
{
    public int helmMaxHealth        = 100;
    public int pauldronsMaxHealth   = 100;
    public int chestplateMaxHealth  = 100;
    public int fauldMaxHealth       = 100;
    public int greavesMaxHealth     = 100;
    public int gauntletsMaxHealth   = 100;

    public int helmCurrentHealth        {get; private set;}
    public int pauldronsCurrentHealth   {get; private set;}
    public int chestplateCurrentHealth  {get; private set;}
    public int fauldCurrentHealth       {get; private set;}
    public int greavesCurrentHealth     {get; private set;}
    public int gauntletsCurrentHealth   {get; private set;}

    bool shattered = false;
    string currentStance = "blood";
    int currentPosition = 0;


    void Awake ()
    {
        helmCurrentHealth       = helmMaxHealth;
        pauldronsCurrentHealth  = pauldronsMaxHealth;
        chestplateCurrentHealth = chestplateMaxHealth;
        fauldCurrentHealth      = fauldMaxHealth;
        greavesCurrentHealth    = greavesMaxHealth;
        gauntletsCurrentHealth  = gauntletsMaxHealth;
    }

    public void attack(PlayerStatsFinal target)
    {   

        int cPos = getPosition();
        int oppCPos = target.getPosition();

        if ( (((cPos + 1) == oppCPos) || ((cPos + 2) == oppCPos)) || (((cPos - 1) == oppCPos) || ((cPos - 2) == oppCPos)) )
        {
            int randomNum = Random.Range(0, 100); 


            //calc based on stance bounus
            string currStance = getStance();

            if(currStance == "flame")
            randomNum += 5;

            string oppCurrStance = target.getStance();

            if (oppCurrStance == "blood")
                randomNum += 10;
        
            if (oppCurrStance == "smoke")
                randomNum -= 10;
            
            if (oppCurrStance == "vine")
                randomNum -= 15;


            //calc based on what blocks what
            if ( (currStance == "flame") && ((oppCurrStance == "smoke") || (oppCurrStance == "stone")) )
                randomNum -=50;

            if ( (currStance == "iron") && ((oppCurrStance == "flame") || (oppCurrStance == "wind")) )
                randomNum -=50;
                
            if ( (currStance == "smoke") && ((oppCurrStance == "iron") || (oppCurrStance == "vine")) )
                randomNum -=50;

            if ( (currStance == "stone") && ((oppCurrStance == "flame") || (oppCurrStance == "wind")) )
                randomNum -=50;

            if ( (currStance == "vine") && ((oppCurrStance == "smoke") || (oppCurrStance == "stone") || (oppCurrStance == "iron")) )
                randomNum -=50;

            if ( (currStance == "wind") && ((oppCurrStance == "iron") || (oppCurrStance == "vine")) )
                randomNum -=50;

            //if both have same stance parry
            if (currStance == oppCurrStance)
                randomNum = 0;

            if (randomNum >= 80) {
                target.TakeDamage(currStance);

                if ((currStance == "wind") && (oppCurrStance != "stone"))
                {
                    if ((cPos < oppCPos) && (oppCPos != 5))
                    target.moveRight();

                    if ((cPos > oppCPos) && (oppCPos != 1))
                    target.moveLeft();
                }//calc windstance if


            }//calc if hit if
        }//calc if in range if
    }//attack

    public void setPosition(int pos)
    {
        currentPosition = pos;
    }

    public int getPosition()
    {
        return currentPosition;
    }

    public void setStance(string stance)
    {
        currentStance = stance;
    }

    public string getStance()
    {
        return currentStance;
    }

    public int getSpeed()
    {
        string currentS = getStance();
        if (currentS == "flame")
            return 1;
        if (currentS == "smoke")
            return 2;
        if (currentS == "vine")
            return 3;
        if (currentS == "wind")
            return 5;//NOTE: this is 5 and not 4 becuase only the first 3 stances are fast enough to hit before they move
                        // TLDR: moving is fast enough to happen before any moves slower than vine stance
        if (currentS == "iron")
            return 6;
        if (currentS == "stone")
            return 7;
        else
            return 0;
    }

    public void moveLeft()
    {
        int Position = getPosition();
        if (Position != 1)
            currentPosition -= 1;
    }

    public void moveRight()
    {
        int Position = getPosition();
        if (Position != 5)
            currentPosition += 1;
    }

    public void TakeDamage (string armorHit)
    {
    
        if (armorHit == "stone"){
            helmCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "iron"){
            pauldronsCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "vine"){
            chestplateCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "wind"){
            fauldCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "smoke"){
            greavesCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "flame"){
            gauntletsCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
       
        if ( (helmCurrentHealth <= 0) || (pauldronsCurrentHealth <= 0) ||
        (chestplateCurrentHealth <= 0)|| (fauldCurrentHealth <= 0)     ||
        (greavesCurrentHealth <= 0)   || (gauntletsCurrentHealth <+ 0))
        {
            Shatter();
            //end game 
            //show winner
            //(optional) show stats 
                //number of cracked armor, rounds taken, ect
        }
    }

    public virtual void Shatter () 
    {
        Debug.Log(transform.name + " has had their armor Shattered.");
        shattered = true;
    }

   public bool hasShattered()
   {
    if (shattered == true)
        return true;
    else
        return false;
   } 


    
}
