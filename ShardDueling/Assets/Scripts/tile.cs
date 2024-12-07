using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public int location;

    public GameObject flameL;
    public GameObject smokeL;
    public GameObject vineL;
    public GameObject windL;
    public GameObject stoneL;
    public GameObject ironL;
    public GameObject flameR;
    public GameObject smokeR;
    public GameObject vineR;
    public GameObject windR;
    public GameObject stoneR;
    public GameObject ironR;


    public void setTile(PlayerStatsFinal p1, PlayerStatsFinal p2)
    {
        setAllOff();

        int loc1 = p1.getPosition();

        if (loc1 == location)
        {
            string currentS = p1.getStance();
            if (currentS == "flame")
            {
                Debug.Log("SET FLAME");
                flameL.gameObject.SetActive(true);
            }
                
            if (currentS == "smoke")
            {
                
                smokeL.gameObject.SetActive(true);
            }

            if (currentS == "vine")
            {
                
                vineL.gameObject.SetActive(true);
            }

            if (currentS == "wind")
            {
                
                windL.gameObject.SetActive(true);
            }

            if (currentS == "iron")
            {
                
                ironL.gameObject.SetActive(true);
            }

            if (currentS == "stone")
            {
                
                stoneL.gameObject.SetActive(true);
            }
        }
        //--------------------------------------------------------
        
        int loc2 = p2.getPosition();
        
        if (loc2 == location)
        {
            string currentS = p2.getStance();
            if (currentS == "flame")
            {
                
                flameR.gameObject.SetActive(true);
            }
                
            if (currentS == "smoke")
            {
               
                smokeR.gameObject.SetActive(true);
            }

            if (currentS == "vine")
            {
                Debug.Log("SET VINE");
                vineR.gameObject.SetActive(true);
            }

            if (currentS == "wind")
            {
              
                windR.gameObject.SetActive(true);
            }

            if (currentS == "iron")
            {
              
                ironR.gameObject.SetActive(true);
            }

            if (currentS == "stone")
            {
               
                stoneR.gameObject.SetActive(true);
            }
        }
    }

    public void setAllOff()
    {

        Debug.Log("SET ALL OFF RUN");
        flameL.gameObject.SetActive(false);
        smokeL.gameObject.SetActive(false);
        vineL.gameObject.SetActive(false);
        windL.gameObject.SetActive(false);
        stoneL.gameObject.SetActive(false);
        ironL.gameObject.SetActive(false);
        
        flameR.gameObject.SetActive(false);
        smokeR.gameObject.SetActive(false);
        vineR.gameObject.SetActive(false);
        windR.gameObject.SetActive(false);
        stoneR.gameObject.SetActive(false);
        ironR.gameObject.SetActive(false);

    }
}
