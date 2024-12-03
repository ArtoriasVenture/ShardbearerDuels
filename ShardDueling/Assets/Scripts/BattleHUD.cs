using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text stanceText;
    public Slider helmSlide;
    public Slider pauldronsSlide;
    public Slider chestplateSlide;
    public Slider fauldSlide;
    public Slider greavesSlide;
    public Slider gauntletsSlide;

    public void SetHUD (PlayerStatsFinal player)
    {
        stanceText.text          = player.getStance();
       
        helmSlide.maxValue       = player.helmMaxHealth; 
        helmSlide.value          = player.helmCurrentHealth;

        pauldronsSlide.maxValue  = player.pauldronsMaxHealth; 
        pauldronsSlide.value     = player.pauldronsCurrentHealth;

        chestplateSlide.maxValue = player.chestplateMaxHealth; 
        chestplateSlide.value     = player.chestplateCurrentHealth;

        fauldSlide.maxValue      = player.fauldMaxHealth; 
        fauldSlide.value          = player.fauldCurrentHealth;

        greavesSlide.maxValue    = player.greavesMaxHealth; 
        greavesSlide.value       = player.greavesCurrentHealth;

        gauntletsSlide.maxValue  = player.gauntletsMaxHealth; 
        gauntletsSlide.value     = player.gauntletsCurrentHealth;
    }


    public void SetHP(int hp)
    {

    }


    

}
