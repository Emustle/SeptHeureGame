using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    private List<GameObject> m_Tiles = new List<GameObject>();
    public int m_GridSizeX = 0, m_GridSizeY = 0;
    //public GameObject[m_GridSizeX][m_GridSizeY];

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            m_Tiles.Add(child.gameObject);
        }
        for (int i = 0; i < m_Tiles.Count; i++)
        {
            if(i > m_GridSizeX)
            {
                m_Tiles[i].GetComponent<TileBehavior>().SetSouthTile(m_Tiles[i - m_GridSizeX]);
            }  
            if(i + m_GridSizeX < m_Tiles.Count)
            {
                Debug.Log(i);
                m_Tiles[i].GetComponent<TileBehavior>().SetNorthTile(m_Tiles[i + m_GridSizeX]);
            }
            if(i - 1 >= 0 && i % m_GridSizeX != 0)
            {
                m_Tiles[i].GetComponent<TileBehavior>().SetWestTile(m_Tiles[i - 1]);
            }
            if (i + 1 % m_GridSizeX != 0 && i + 1 < m_Tiles.Count)
            {
                m_Tiles[i].GetComponent<TileBehavior>().SetEastTile(m_Tiles[i + 1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
