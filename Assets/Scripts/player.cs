using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public AudioSource sourceAudioPas;
    public AudioClip PasDeJo;
    public AudioClip cookieSon;
    float nombreCookie = 0;
    public GameObject cookie;
    public GameObject cookie1;
    public GameObject cookie2;
    private Vector3 m_DesiredDirection;
    private Vector3 m_NextPos;
    private bool m_IsNextPosSet;

    public GameObject Bed;

    private Quaternion m_TargetRot;
    private float m_RotSpeed;

    //private Rigidbody m_Rb;
    private bool m_IsMoving;
    private bool m_MovementAccepted;
    //private bool m_IsNextPosSet;
    private float m_KeyRepeatRate = 0.5f;
    private float m_InputHoldTime;

    private Animator m_Animator;

    [SerializeField]
    private GameObject m_StartingTile;
    private GameObject m_CurrentTile;

    private Collider m_Collider;
    private bool m_GameIsFinished = false;
    private bool m_GotAllObjects;
    private GameObject[] m_Items = null;
    private int m_NbObjectsRetrieved;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_CurrentTile = m_StartingTile;
        m_RotSpeed = 800f;
        //m_Rb = GetComponent<Rigidbody>();

        m_NextPos = transform.position;
        m_GotAllObjects = false;
        m_NbObjectsRetrieved = 0;
        m_IsMoving = false;
        m_IsNextPosSet = false;
        m_Collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 t_MovementVector = new Vector3(0, 0.2f, 0);

        //Debug.Log(gameObject.transform.position.z + "/" + CurrentTile.transform.position.z);
        //Debug.Log(m_GameIsFinished);
        if (m_GameIsFinished)
        {
            return;
        }
        
        //ROTATION ET DEPLACEMENT
        if(!m_IsMoving && m_CurrentTile.GetComponent<TileBehavior>().TileType == TileBehavior.TileTypeEnum.BED && m_GotAllObjects)
        {
            m_Animator.SetBool("IsMoving", false);
            m_Animator.SetTrigger("GoToSleep");
            //transform.position = Vector3.MoveTowards( transform.position, new Vector3(Bed.transform.GetChild(0).transform.position.x, 0.2f, Bed.transform.GetChild(0).transform.position.z), 5 * Time.deltaTime);
            transform.position = new Vector3(Bed.transform.GetChild(0).transform.position.x, 0.2f, Bed.transform.GetChild(0).transform.position.z);
            transform.eulerAngles = new Vector3(0, -90, 0);
            m_GameIsFinished = true;
            StartCoroutine(CameraBehavior.Instance.FadeBlackScreen(1, 3, 0));
            StartCoroutine(CameraBehavior.Instance.WaitForNextLevel(3));
            return;
        }

        if (!m_IsMoving && m_CurrentTile.GetComponent<TileBehavior>().TileType == TileBehavior.TileTypeEnum.PICKABLE && !m_GotAllObjects)
        {
            //Destruction de l'item
            if (m_CurrentTile.transform.childCount > 0)
            {
                Destroy(m_CurrentTile.transform.GetChild(0).gameObject);
            }
            nombreCookie += 1;
            if (nombreCookie == 1)
            {
                cookie.SetActive(true);
            }
            else if (nombreCookie == 2)
            {
                cookie1.SetActive(true);
            }
            else if (nombreCookie == 3)
            {
                cookie2.SetActive(true);
            }
            sourceAudioPas.PlayOneShot(cookieSon);
            //Désactivation du pickable de la case
            m_CurrentTile.GetComponent<TileBehavior>().TileType = TileBehavior.TileTypeEnum.WALKABLE;

            Debug.LogWarning("Le joueur a ramassé un objet");
            //Ajout des points
            m_NbObjectsRetrieved++;

            //Vérifier que la scène contient encore des objets à ramasser
            if (!RemainsItems())
                m_GotAllObjects = true;
            else
                Debug.LogWarning("Il reste des objets à ramasser");
        }


        m_InputHoldTime += Time.deltaTime;

        float t_HorizontalDir = Input.GetAxis("Horizontal");
        float t_VerticalDir = Input.GetAxis("Vertical");
        if (t_VerticalDir != 0 || t_HorizontalDir != 0)
        {
            m_Animator.SetBool("IsMoving", true);
            //Debug.Log("AAAA");
        }
        else
        {
            m_Animator.SetBool("IsMoving", false);
        }
        if ((t_HorizontalDir != 0 || t_VerticalDir != 0) && !m_IsMoving && m_InputHoldTime > m_KeyRepeatRate)
        {
            
            m_InputHoldTime = 0;
            
            if (t_HorizontalDir > 0f)
                t_VerticalDir = 0;
            else if (t_VerticalDir > 0f)
                t_HorizontalDir = 0;

            m_DesiredDirection = new Vector3(t_HorizontalDir, 0, t_VerticalDir);
            
        }
        if (m_DesiredDirection != new Vector3(0, 0, 0))
        {
            m_TargetRot = Quaternion.LookRotation(m_DesiredDirection, Vector3.up);
        }
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRot, Time.deltaTime*m_RotSpeed);
     
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
                        //m_Collider.enabled = true;
                        m_IsMoving = true;
                        m_NextPos = transform.position + transform.forward;
                        sourceAudioPas.PlayOneShot(PasDeJo);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, m_NextPos, 5 * Time.deltaTime);
                    }

                    if (Vector3.Distance(transform.position, m_NextPos) < 0.001)
                    {
                        //m_Collider.enabled = false;
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

    private bool RemainsItems()
    {
        m_Items = GameObject.FindGameObjectsWithTag("item");
        Debug.Log(m_Items.Length);

        return m_Items.Length-1 > 0 ? true : false;
    }

    private void OnTriggerEnter(Collider a_Collider)
    {
        if (a_Collider.GetComponent<Animator>())
        {
            //Debug.Log("AAAAAAAAA");
            m_GameIsFinished = true;
            StartCoroutine(CameraBehavior.Instance.FadeBlackScreen(1, 1, 0));
            StartCoroutine(CameraBehavior.Instance.FadeGameOverScreen(1, 1, 0));
        }
        //m_GameIsFinished = true;

    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(m_CurrentTile.transform.position, m_CurrentTile.transform.lossyScale);
    }*/
}
