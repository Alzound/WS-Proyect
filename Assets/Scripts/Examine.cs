using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Examine : MonoBehaviour
{

    Camera cam; 
    GameObject selectedObj;
    RaycastHit hit;
    public int i = 0; 

    Vector3 originPosition;
    Vector3 originRotation;

    bool examinable;
    bool destruction = false;
  
    RaycastHit Hit;

    public ScrVoiceOverLogic scrVoiceOverLogic;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        examinable = false; 
    }


    // Update is called once per frame
    void Update()
    {
            onSelectedObj();

            turnAround();

            ExitExamination();

    }

    //All of the following code helps me to know when the raycast hits and object with a the specific tag. 
    private void onSelectedObj()
    {
        if (Input.GetMouseButtonDown(0) && examinable == false)
        {

            //If it is only an item then the player can grab it and then rotate it.
            //Then the object returns to it's original position because the value of it was save in another variable. 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 8) && hit.transform.tag == "item")
            {

                selectedObj = hit.transform.gameObject;

                originPosition = selectedObj.transform.position;
                originRotation = selectedObj.transform.rotation.eulerAngles;

                selectedObj.transform.position = cam.transform.position + (transform.forward * 3.1f);

                
                Time.timeScale = 0;

                examinable = true;
            }

            //Same as before but when it's a keyobject the player takes it, and the game destroys it, so we can save the hard work of doing an inventory. 
            else if(Physics.Raycast(ray, out hit, 8) && hit.transform.tag == "KeyObject")
            {
                scrVoiceOverLogic.ReproduceVoiceOver(hit.transform.gameObject.GetComponent<VoiceOverTrigger>().voiceOverIndex);

                selectedObj = hit.transform.gameObject;

                    originPosition = selectedObj.transform.position;
                    originRotation = selectedObj.transform.rotation.eulerAngles;

                    selectedObj.transform.position = cam.transform.position + (transform.forward * 3.1f);


                Time.timeScale = 0; 

                    destruction = true; 
                
            }
            //Originally this following lines of code where in case the player grabbed the gun in the final segment. 
            //But the professor didn't like it, so... There's that, a thing that could have been but not very subtle. 
            /*
            else if (Physics.Raycast(ray, out hit, 8) && hit.transform.tag == "TheEnd")
            {
                Debug.Log("Juasjuas");
              


                selectedObj = hit.transform.gameObject;

                originPosition = selectedObj.transform.position;
                originRotation = selectedObj.transform.rotation.eulerAngles;

                selectedObj.transform.position = cam.transform.position + (transform.forward * 3.1f);


                Time.timeScale = 0;

                theEnd = true; 
            }

            */
        }
    }
    private void turnAround()
    {
        //This is going to rotate the object taking the movement from the camera. 
        //Also, bless Youtube.
        if(Input.GetMouseButton (0) && examinable)
        {
            float rotationsSpeed = 15;

            float xAxis = Input.GetAxis("Mouse X") * rotationsSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationsSpeed;

            selectedObj.transform.Rotate(Vector3.up, -xAxis, Space.World);
            selectedObj.transform.Rotate(Vector3.right, -yAxis, Space.World);
        }
    }

    private void ExitExamination()
    {
        //With this when the player clicks the right button of the mouse the object returns to it's original position.
        if(Input.GetMouseButtonDown(1) && examinable )
        {
            selectedObj.transform.position = originPosition;
            selectedObj.transform.eulerAngles = originRotation;

            Time.timeScale = 1;
            examinable = false;

           
        }
        //But if it's this case, and the destruction value coming from keyobject is true then the object is destroyed when pressed right click. 
        else if (Input.GetMouseButtonDown(1)&&destruction==true)
        {
            i++;
            examinable = false;
            Destroy(selectedObj);
            Time.timeScale = 1; 
         
        }
   
    }
}

