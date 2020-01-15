using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightBehavior : MonoBehaviour
{
    private GameObject m_MainLight;
    private float m_DesiredIntensity;
    private Light[] m_LightComps;


    // Start is called before the first frame update
    void Start()
    {
        m_LightComps = GetComponentsInChildren<Light>();
        foreach(Light t_light in m_LightComps)
        {
            t_light.intensity = 0f;
        }
        m_DesiredIntensity = 0.8f;
        m_MainLight = GameObject.Find("Directional Light");
    }

    // Update is called once per frame
    void Update()
    {
        AjustIntensity();
    }

    private void AjustIntensity()
    {
        foreach(Light t_light in m_LightComps)
        {
            t_light.intensity = (1 - m_MainLight.GetComponent<Light>().intensity) * m_DesiredIntensity;
        }
    }
}
