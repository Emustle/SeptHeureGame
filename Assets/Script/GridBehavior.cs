using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    private List<GameObject> m_Tiles = new List<GameObject>();
    [SerializeField]
    private int m_GridSizeX = 0, m_GridSizeY = 0;
    //public GameObject[m_GridSizeX][m_GridSizeY];

    // Start is called before the first frame update
    void Start()
    {
        int t_NumberSorted = 0;
        int t_SortingColumn = 0;
        int t_SortingRow = 0;
        //NOTE: TOUT VA PLANTER SI VOUS NE DONNEZ PAS LES BONNES POSITIONS X/Y AUX TUILES OU SI ELLES SONT MALS ASSIGNÉES TOUT COURT!!!!!!
        //Pour éviter cela, il faut A B S O L U M E N T que les coordonnées locales des tuiles soient PRÉCISÉMENT de 0,0,0 en montant! 

        
        while(t_NumberSorted != transform.childCount)
        {
            foreach (Transform child in transform)
            {
                if(child.GetComponent<TileBehavior>().PositionX == t_SortingColumn && child.GetComponent<TileBehavior>().PositionY == t_SortingRow)
                {
                    m_Tiles.Add(child.gameObject);
                    t_NumberSorted++;
                    if(t_SortingColumn + 1 == m_GridSizeX)
                    {
                        t_SortingColumn = 0;
                        t_SortingRow++;
                    } else
                    {
                        t_SortingColumn++;
                    }
                }
            
            }
        } 
          

        for (int i = 0; i < m_Tiles.Count; i++)
        {
            if(i >= m_GridSizeX)
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
            if ((i + 1) % m_GridSizeX != 0 && i + 1 < m_Tiles.Count)
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
