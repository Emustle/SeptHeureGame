using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationJourNuit : MonoBehaviour
{
    public int timer;
    float rotationSpeed = -1.25f;
    Vector3 currentEulerAngles = new Vector3 (50,0,0);
    Quaternion currentRotation;
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        if(timer == 0)
        {
            Debug.Log("je sais pas ce que je fais");
        }
        x = 1 - x;
        
    }
    void Update()
    {
        //modifying the Vector3, based on input multiplied by speed and time
        currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

        //moving the value of the Vector3 into Quanternion.eulerAngle format
        currentRotation.eulerAngles = currentEulerAngles;

        //apply the Quaternion.eulerAngles change to the gameObject
        transform.rotation = currentRotation;
        //modifying the Vector3, based on input multiplied by speed and time
        if(currentEulerAngles.x <= -25f)
        {
            rotationSpeed = 0;
        }
        
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        // Use eulerAngles to show the euler angles of the quaternion stored in Transform.Rotation
        GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X:" + x + " Y:" + y + " Z:" + z, style);

        //outputs the Quanternion.eulerAngles value
        GUI.Label(new Rect(10, 25, 0, 0), "CurrentEulerAngles: " + currentEulerAngles, style);

        //outputs the transform.eulerAngles of the GameObject
        GUI.Label(new Rect(10, 50, 0, 0), "GameObject World Euler Angles: " + transform.eulerAngles, style);
    }
               
  
 }

