using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

 

    private void Start()
    {
       
    }


    void Update()
    {
      
            Movement();
   
    }

    void Movement()
    {
        float movementSpeed = 80;

        //Each of the if has a transform below them, why is that? Because if i use the gameobject<Rigidbody>.Addforce it will move my object, in this case the player, but at the same time it would move the pivot, 
        //as a result of this the movement of the camera is unstable. 
        //With this in mind my thinking is that for now this would be the movement of my player (wich by the way, can go in the direction of the camera) but later i could use the intructions of Add force to the object, in this case
        //The ball that spins the player, only making it a children of my player so they dont interfere in their own movements... althought now that i see a little more by making it a children of the player the isKinematic applies to the ball too, hmmm. 


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //This controls the direction of the player in local scale, just taking the coordinates of the direction wich the player is facing. 
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
        //This commands can quit the game with esc, or pause, and also resume the game. 
        else if (Input.GetKey(KeyCode.Tab))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            //This command stops the game, so it's a pause. 
            Time.timeScale = 0;
        }
      

    }
}
