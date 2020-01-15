using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3 m_DesiredDirection;
    private Vector3 m_NextPos;
    private bool m_IsNextPosSet;

    private Quaternion m_TargetRot;
    private float m_RotSpeed;

    //private Rigidbody m_Rb;
    private bool m_IsMoving;

    private float m_KeyRepeatRate = 0.3f;
    private float m_InputHoldTime;

    public GameObject m_SpawnTile;
    private GameObject m_CurrentTile;

    // Start is called before the first frame update
    void Start()
    {
        //m_Rb = GetComponent<Rigidbody>();
        m_RotSpeed = 600f;
        m_InputHoldTime = 0;
        m_IsMoving = false;
        m_IsNextPosSet = false;

        if (m_SpawnTile == null)
            throw new System.Exception("La tuile de spawn du joueur est manquante");
        else
        {
            m_CurrentTile = m_SpawnTile;
            transform.position = m_SpawnTile.transform.position + Vector3.up;
        }

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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRot, m_RotSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.rotation.eulerAngles.y) % 90 == 0 && m_IsMoving)
        {
            if (!m_IsNextPosSet)
            {
                m_IsNextPosSet = true;
                m_NextPos = transform.position + transform.forward;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_NextPos, 5 * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, m_NextPos) < 0.001)
            {
                m_IsMoving = false;
                m_IsNextPosSet = false;
            }
        }
    }

}
