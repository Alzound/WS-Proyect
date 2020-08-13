using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio; 
using UnityEngine;

public class Opendoors : MonoBehaviour
{
   
    AudioSource audioData;
    public int flag;


    // Start is called before the first frame update
    void Awake()
    {
        //A nice sound of opening door.
        Debug.Log("s");
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        flag = GameObject.Find("Main Camera").GetComponent<Examine>().i;
        Options();
        TheEnd();
    }

    void Options()
    {
        switch (flag)
        {
            //Well, originally it was an if else statement right here, but then i questioned myself about my life, and one thing led to another, either way, i changed it
            //the same way she changed me xD (bad pun) so now it takes flag, witch has the value taken from examine whenever an object is pick wich increments i. 
            //And if you pick one object that door with the corresponding value of i is going to be open... ah... im tired of this.
            case 1:
                if (gameObject.tag == "Door1")
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                break;

            case 2:

                if(gameObject.tag == "Door2")
                { 
        
                    gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                }

                break;

            case 3:

                if (gameObject.tag == "Door3")
                {

                    gameObject.transform.rotation = Quaternion.Euler(0, 1, 0);
                 
                }

                break;

            case 4:

                if (gameObject.tag == "Door4")
                {

                    gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);

                }

                break;

            case 5:

                if (gameObject.tag == "Door5")
                {

                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

                }

                break;
        }       
    }

    void TheEnd()
    {
        if(GameObject.Find("Player").GetComponent<TheEndTrigger>().close==true && gameObject.tag=="Door3")
        {
            //When the player enters the collider in the script TheEndTrigger i can enter this void and close the door with the tag Door 3 so the player is trapped, like me... right now. 
               gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);

        }
    }

}
