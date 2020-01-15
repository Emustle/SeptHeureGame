using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerHistoire : MonoBehaviour
{
    public GameObject commencerCanvas;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void commencer()
    {
        SceneManager.LoadScene("TestHV");
    }
}
