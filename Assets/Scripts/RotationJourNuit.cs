using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationJourNuit : MonoBehaviour
{
    public int timer;
    float rotationSpeed = -1.25f;
    private float m_RotationToGo;
    private float m_FullRotation;
    private float m_InitialRotation;
    [SerializeField]
    private float m_TargetRotation;
    private Vector3 m_CurrentEulerAngles;
    //Vector3 currentEulerAngles = new Vector3 (50,0,0);
    Quaternion currentRotation;
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        m_InitialRotation = transform.rotation.eulerAngles.x;
        m_FullRotation = m_InitialRotation - m_TargetRotation;
        m_RotationToGo = m_FullRotation;
        m_CurrentEulerAngles = new Vector3(m_InitialRotation, 0, 0);
        if (timer == 0)
        {
            Debug.Log("je sais pas ce que je fais");
        }
        x = 1 - x;
        
    }
    void Update()
    {

        //modifying the Vector3, based on input multiplied by speed and time
        m_CurrentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

        //Réduire l'intensité
        GetComponent<Light>().intensity -= Time.deltaTime * 0.02f;

        //moving the value of the Vector3 into Quanternion.eulerAngle format
        currentRotation.eulerAngles = m_CurrentEulerAngles;

        //apply the Quaternion.eulerAngles change to the gameObject
        transform.rotation = currentRotation;
        //modifying the Vector3, based on input multiplied by speed and time
        m_RotationToGo = m_CurrentEulerAngles.x;
        if (m_CurrentEulerAngles.x <= m_TargetRotation)
        {
            rotationSpeed = 0;
        }

        CameraBehavior.Instance.TickClockNeedle(m_RotationToGo / m_FullRotation);
        
    }

    void OnGUI()
    {
        //GUIStyle style = new GUIStyle();
        //style.fontSize = 24;
        // Use eulerAngles to show the euler angles of the quaternion stored in Transform.Rotation
        //GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X:" + x + " Y:" + y + " Z:" + z, style);

        //outputs the Quanternion.eulerAngles value
        //GUI.Label(new Rect(10, 25, 0, 0), "CurrentEulerAngles: " + currentEulerAngles, style);

        //outputs the transform.eulerAngles of the GameObject
        //GUI.Label(new Rect(10, 50, 0, 0), "GameObject World Euler Angles: " + transform.eulerAngles, style);
    }
               
  
 }

