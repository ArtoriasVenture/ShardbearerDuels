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

    

    void Awake ()
    {
        helmCurrentHealth       = helmMaxHealth;
        pauldronsCurrentHealth  = pauldronsMaxHealth;
        chestplateCurrentHealth = chestplateMaxHealth;
        fauldCurrentHealth      = fauldMaxHealth;
        greavesCurrentHealth    = greavesMaxHealth;
        gauntletsCurrentHealth  = gauntletsMaxHealth;
    }



    public void TakeDamage (string armorHit)
    {
    
        if (armorHit == "helm"){
            helmCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "pauldrons"){
            pauldronsCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "chestplate"){
            chestplateCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "fauld"){
            fauldCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "greaves"){
            greavesCurrentHealth -= 50;
            Debug.Log(transform.name + " takes 50 damage.");
        }
        if (armorHit == "gauntlets"){
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
        Debug.Log(transform.name + " has Shattered.");
    }
}
