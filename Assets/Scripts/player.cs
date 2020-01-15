using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float m_RotationDegrees;

    private Vector3 m_FacedDirection;
    private Vector3 m_DesiredDirection;

    [SerializeField] private float m_RotSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t_HorizontalDir = Input.GetAxis("Horizontal");
        float t_VerticalDir = Input.GetAxis("Vertical");

        m_DesiredDirection = new Vector3(t_HorizontalDir, 0, t_VerticalDir);

        Quaternion rot = Quaternion.LookRotation(m_DesiredDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime*m_RotSpeed);
        
    }
}
