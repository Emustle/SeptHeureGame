using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationJourNuit : MonoBehaviour
{
    public int timer;
    float rotationSpeed = -10f;
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
        
        StartCoroutine(rotationLight(-25f, 0.1f));

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


    public IEnumerator rotationLight(float rotationDeFin, float a_Duration)
    {
     
        
            
        
    /*
        float t_ElapsedTime = 0f;
        float t_InitialRotation = 50f;
        bool test = true;
        currentEulerAngles = new Vector3(t_InitialRotation, y, z);
        while (t_ElapsedTime / a_Duration <= 1)
        {

            float t = t_ElapsedTime / a_Duration;
            
            x = 1 - x;
            //Debug.Log(x);
            Debug.Log(t);
            while (test != false)
            {


                currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;
                Debug.Log(Time.deltaTime);
                Debug.Log(currentEulerAngles);
                if (currentEulerAngles.x == -25f)
                {
                    Debug.Log(x);
                    Debug.Log("rentre");
                    //test = false;
                }
                Debug.Log(currentEulerAngles);
                //moving the value of the Vector3 into Quanternion.eulerAngle format
                currentRotation.eulerAngles = currentEulerAngles;

                //apply the Quaternion.eulerAngles change to the gameObject
                transform.rotation = currentRotation;
                Debug.Log(t_InitialRotation);
                
                Debug.Log(x);

                if (t_InitialRotation != 49f)
                {
                    //test = false;
                    Debug.Log(test);
                }
            }
             
             t_ElapsedTime += Time.deltaTime;
             //Debug.Log(t_ElapsedTime);
             yield return null; 
         } 
         */
            yield break;
        }
    }

