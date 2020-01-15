using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerInGame : MonoBehaviour
{
    public GameObject MenuPause;
    // Start is called before the first frame update
    void Start()
    {
        MenuPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseMenu();
        }
        
    }
    public void PauseMenu()
    {
        Time.timeScale = 0f;
        MenuPause.SetActive(true);
        Debug.Log("PauseMenu");
    }

    public void retourMenu()
    {
        Debug.Log("retour menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void retourGame()
    {
        Debug.Log("retour menu");
        MenuPause.SetActive(false);
        Time.timeScale = 1f;

    }
}
