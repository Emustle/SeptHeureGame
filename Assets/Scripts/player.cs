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
    private bool m_MovementAccepted;
    private float m_KeyRepeatRate = 0.3f;
    private float m_InputHoldTime;

    [SerializeField]
    private GameObject m_StartingTile;
    private GameObject m_CurrentTile;

    private Collider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentTile = m_StartingTile;
        m_RotSpeed = 800f;

        m_NextPos = transform.position;
        m_IsMoving = false;
        m_IsNextPosSet = false;
        m_Collider = gameObject.GetComponent<BoxCollider>();
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
            
            if (t_HorizontalDir > 0f)
                t_VerticalDir = 0;
            else if (t_VerticalDir > 0f)
                t_HorizontalDir = 0;

            m_DesiredDirection = new Vector3(t_HorizontalDir, 0, t_VerticalDir);
            
        }

        m_TargetRot = Quaternion.LookRotation(m_DesiredDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRot, Time.deltaTime*m_RotSpeed);
        Debug.Log(transform.rotation.eulerAngles.y);
        if (m_TargetRot == transform.rotation)
        {


            if (t_HorizontalDir < 0f && transform.rotation.eulerAngles.y == 270 && m_CurrentTile.GetComponent<TileBehavior>().WestTile &&
                m_CurrentTile.GetComponent<TileBehavior>().WestTile.GetComponent<TileBehavior>().TileType != TileBehavior.TileTypeEnum.OBSTACLE)
            {
                m_MovementAccepted = true;
            }
            else if (t_HorizontalDir > 0f && transform.rotation.eulerAngles.y == 90 && m_CurrentTile.GetComponent<TileBehavior>().EastTile
                && m_CurrentTile.GetComponent<TileBehavior>().EastTile.GetComponent<TileBehavior>().TileType != TileBehavior.TileTypeEnum.OBSTACLE)
            {
                m_MovementAccepted = true;
            }
            else if (t_VerticalDir < 0f &&transform.rotation.eulerAngles.y == 180 && m_CurrentTile.GetComponent<TileBehavior>().SouthTile &&
                m_CurrentTile.GetComponent<TileBehavior>().SouthTile.GetComponent<TileBehavior>().TileType != TileBehavior.TileTypeEnum.OBSTACLE)
            {
                m_MovementAccepted = true;
            }
            else if (t_VerticalDir > 0f && transform.rotation.eulerAngles.y == 0 && m_CurrentTile.GetComponent<TileBehavior>().NorthTile &&
                m_CurrentTile.GetComponent<TileBehavior>().NorthTile.GetComponent<TileBehavior>().TileType != TileBehavior.TileTypeEnum.OBSTACLE)
            {
                m_MovementAccepted = true;

            }
            if (m_MovementAccepted)
            {
                if (Mathf.Abs(transform.rotation.eulerAngles.y) % 90 == 0)
                {
                    if (!m_IsNextPosSet && !m_IsMoving)
                    {
                        m_IsNextPosSet = true;
                        m_Collider.enabled = true;
                        m_IsMoving = true;
                        m_NextPos = transform.position + transform.forward;
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, m_NextPos, 5 * Time.deltaTime);
                    }

                    if (Vector3.Distance(transform.position, m_NextPos) < 0.01)
                    {
                        m_Collider.enabled = false;
                        m_IsMoving = false;
                        m_IsNextPosSet = false;
                        m_MovementAccepted = false;
                    }


                }
            }
            else
            {
                m_IsMoving = false;
            }
        }
    }

    public GameObject CurrentTile
    {
        get { return m_CurrentTile; }
        set { m_CurrentTile = value; }
    }

}
