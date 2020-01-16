using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Cheatcode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject test;
    public string analyse;
    public GameObject bonhomme;
    bool estPasseDansVerification = false;
    public float compteur;
    public float vitesseDeReduction;
    public float duree;
    void Start()
    {
      
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (estPasseDansVerification)
        {
            compteur += Time.deltaTime;
        }
        
        if (Input.GetKeyDown("t"))
        {
            Afficher();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            analyse = test.GetComponentInChildren<InputField>().transform.Find("Text").GetComponent<Text>().text;
            Verification();
            test.SetActive(false);
        }
        if(compteur >= duree)
        {
            bonhomme.GetComponent<AIPath>().maxSpeed = 2.5f;
            estPasseDansVerification = false;
        }
    }
    public void Afficher()
    {
        test.SetActive(true);
        test.GetComponentInChildren<InputField>().GetComponentInChildren<Text>().GetComponent<Text>().text = "Tape le mot de passe";
        

    }
    public void Verification()
    {
        if(analyse == "sept")
        {


            bonhomme.GetComponent<AIPath>().maxSpeed = vitesseDeReduction;
            // var ai = bonhomme.GetComponent<AIPath>().maxSpeed;
            //Debug.Log(ai);
            estPasseDansVerification = true;
        }
        Debug.Log(analyse);
    }
}
