
using UnityEngine;

public class PlayerStatsTest : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth {get; private set;}

    public Stat damage;
    public Stat armor;

    void Awake ()
    {
        currentHealth = maxHealth;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }


    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage  + " damage.");

        if (currentHealth <= 0 )
        {
            Die();
            //end game 
            //show winner
            //(optional) show stats 
                //number of cracked armor, rounds taken, ect
        }
    }

    public virtual void Die () 
    {
        Debug.Log(transform.name + " died.");
    }


}
