using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
       

    public void PlayGame()
    {
        //This plays the next scene in the index, every time the player clicks on the button 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        //This actually quit the aplication when the player clicks on the button attached to the script.
        Debug.Log("QUIT THE MOTHERFUCKING SNAKES ON MY MOTHERFUCKING SNAKE!!");
        Application.Quit();
    }

}

