using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

public class TheEndFade : MonoBehaviour
{
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        //So i realize that when you have a coroutine starting it will trigger the event even if you didn't want that, but well,
        //This code starts the coroutine in order for the animation of the canvas fades to black and then...
        if (GameObject.Find("Player").GetComponent<TheEndTrigger>().close == true)
        {

            StartCoroutine(myFunction());
            Debug.Log("Enter");
        }
    }

    IEnumerator myFunction()
    {
       
            Debug.Log("Shit Negro that's all you had to say");

            //I wanted to wait for the animation the time it took the player to listen to the final audio. 
            //But here i am... waiting for the audios... 
            
            yield return new WaitForSeconds(5);

            animator.SetTrigger("FadeOut");

            yield return new WaitForSeconds(5);
            
            //The scene changes to the credits. 

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
        yield return null; 

    }
}
