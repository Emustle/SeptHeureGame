using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public enum TileTypeEnum {WALKABLE, OBSTACLE, BED};
    public TileTypeEnum TileType;
    private int m_PositionX, m_PositionY;
    [SerializeField]
    private GameObject m_NorthTile;
    [SerializeField]
    private GameObject m_EastTile;
    [SerializeField]
    private GameObject m_SouthTile;
    [SerializeField]
    private GameObject m_WestTile;

    private void Awake()
    {
        m_PositionX = (int)transform.localPosition.x;
        m_PositionY = (int)transform.localPosition.z;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject NorthTile
    {
        get { return m_NorthTile; }
        set { m_NorthTile = value; }
    }
    public GameObject EastTile
    {
        get { return m_EastTile; }
        set { m_EastTile = value; }
    }
    public GameObject SouthTile
    {
        get { return m_SouthTile; }
        set { m_SouthTile = value; }
    }
    public GameObject WestTile
    {
        get { return m_WestTile; }
        set { m_WestTile = value; }
    }


    public int PositionX
    {
        get { return m_PositionX; }
    }

    public int PositionY
    {
        get { return m_PositionY; }
    }

    private void OnTriggerEnter(Collider a_Collider)
    {
        
        a_Collider.GetComponent<player>().CurrentTile = gameObject;
    }
}
