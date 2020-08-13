using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //This helps with the movement of the camera for the porpuse of examine it. 
        if (GameObject.Find("Main Camera").GetComponent<Examine>().i == 6)
        {
            this.gameObject.transform.position = new Vector3(47, 3, 43);
        }
    }
}
