using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TheEndTrigger : MonoBehaviour
{
    public bool playerIsInside=false;
    public bool close = false; 

    private void OnTriggerEnter() //el avatar juega marco polo, toco a alguien
    {
     //This helps me out for knowing when the player enters the collider, so i can close the door behind him.
        playerIsInside = true;
        if(playerIsInside==true)
        {
            //Once the player is inside the option close is true, and the script for open doors knows it.  
            close = true; 
        }
    }
}
