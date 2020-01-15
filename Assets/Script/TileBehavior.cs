using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public enum m_TileTypeEnum {WALKABLE, OBSTACLE};
    public m_TileTypeEnum m_TileType;
    [SerializeField]
    private GameObject m_NorthTile;
    [SerializeField]
    private GameObject m_EastTile;
    [SerializeField]
    private GameObject m_SouthTile;
    [SerializeField]
    private GameObject m_WestTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNorthTile(GameObject a_Tile)
    {
        m_NorthTile = a_Tile;
    }
    public void SetEastTile(GameObject a_Tile)
    {
        m_EastTile = a_Tile;
    }
    public void SetSouthTile(GameObject a_Tile)
    {
        m_SouthTile = a_Tile;
    }
    public void SetWestTile(GameObject a_Tile)
    {
        m_WestTile = a_Tile;
    }
}
