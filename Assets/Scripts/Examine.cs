using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examine : MonoBehaviour
{
    Camera cam; 
    GameObject selectedObj;

    Vector3 originPosition;
    Vector3 originRotation;

    bool examinable; 


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

    private void onSelectedObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            selectedObj = hit.transform.gameObject;

            originPosition = selectedObj.transform.position;
            originRotation = selectedObj.transform.rotation.eulerAngles;

            selectedObj.transform.position = cam.transform.position + (transform.forward * 3f);

            Time.timeScale = 0;

            examinable = true; 
        }
    }
    private void turnAround()
    {
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
        if(Input.GetMouseButtonDown(1) && examinable)
        {
            selectedObj.transform.position = originPosition;
            selectedObj.transform.position = originRotation;

            Time.timeScale = 1;

            examinable = false; 
        }
    }
}

