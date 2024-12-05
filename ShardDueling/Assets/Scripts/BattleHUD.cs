using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
[SerializeField] 


public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI stanceText;
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
        chestplateSlide.value    = player.chestplateCurrentHealth;

        fauldSlide.maxValue      = player.fauldMaxHealth; 
        fauldSlide.value         = player.fauldCurrentHealth;

        greavesSlide.maxValue    = player.greavesMaxHealth; 
        greavesSlide.value       = player.greavesCurrentHealth;

        gauntletsSlide.maxValue  = player.gauntletsMaxHealth; 
        gauntletsSlide.value     = player.gauntletsCurrentHealth;
    }


    public void SetHP(PlayerStatsFinal hit)
    {
        helmSlide.value = hit.getHelmHp();     
        pauldronsSlide.value = hit.getpauldronsHp();       
        chestplateSlide.value = hit.getChestplateHp();       
        fauldSlide.value = hit.getFauldHp();      
        greavesSlide.value = hit.getGreavesHp();   
        gauntletsSlide.value = hit.getGauntletsHp();
    }


    

}
