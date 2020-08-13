using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject trigger;

    private void Start()
    {

        trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(this.gameObject.tag == "Nightmare" && GameObject.Find("Main Camera").GetComponent<Examine>().i == 6 )
         {

            trigger.SetActive(true);
      
         }
    }
}
