using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SurDeQuitterCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        if(SurDeQuitterCanvas)
            SurDeQuitterCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void play()
    {
        Debug.Log("test");
        
        SceneManager.LoadScene("histoire");
    }
    public void SurDeQuitter()
    {
        SurDeQuitterCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }
    public void CancelQuitter()
    {
        SurDeQuitterCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }
    public void QuitterVriament()
    {
        Application.Quit();
    }

    public void NavMenu()
    {
        Debug.Log("OK");
        SceneManager.LoadScene("menu");
    }


}
