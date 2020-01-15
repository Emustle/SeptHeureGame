using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3 m_DesiredDirection;
    private Vector3 m_NextPos;

    private Quaternion m_TargetRot;
    private float m_RotSpeed;

    private Rigidbody m_Rb;
    private bool m_IsMoving;
    private bool m_IsNextPosSet;

    private float m_KeyRepeatRate = 0.3f;
    private float m_InputHoldTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_RotSpeed = 600f;
        m_Rb = GetComponent<Rigidbody>();

        m_NextPos = transform.position;
        m_IsMoving = false;
        m_IsNextPosSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ROTATION ET DEPLACEMENT

        m_InputHoldTime += Time.deltaTime;

        float t_HorizontalDir = Input.GetAxis("Horizontal");
        float t_VerticalDir = Input.GetAxis("Vertical");

        if ((t_HorizontalDir != 0 || t_VerticalDir != 0) && !m_IsMoving && m_InputHoldTime > m_KeyRepeatRate)
        {
            m_InputHoldTime = 0;

            if (t_HorizontalDir != 0)
                t_VerticalDir = 0;
            if (t_VerticalDir != 0)
                t_HorizontalDir = 0;

            m_DesiredDirection = new Vector3(t_HorizontalDir, 0, t_VerticalDir);
            m_IsMoving = true;
        }

        m_TargetRot = Quaternion.LookRotation(m_DesiredDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRot, Time.deltaTime*m_RotSpeed);

        if (Mathf.Abs(transform.rotation.eulerAngles.y) % 90 == 0 && m_IsMoving)
        {
            if (!m_IsNextPosSet)
            {
                m_IsNextPosSet = true;
                m_NextPos = transform.position + transform.forward * 2;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_NextPos, 5 * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, m_NextPos) < 0.01)
            {
                m_IsMoving = false;
                m_IsNextPosSet = false;
            }

        }

    }

}
