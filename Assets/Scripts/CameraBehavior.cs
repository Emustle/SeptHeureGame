using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 m_Offset;
    private GameObject m_BlackScreen;
    private GameObject m_Needle;

    public static CameraBehavior m_Instance;
    public static CameraBehavior Instance
    {
        get
        {
            if (m_Instance == null)
                Debug.LogError("CameraBehavior has no instance.");

            return m_Instance;
        }
    }
    private void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_BlackScreen = gameObject.transform.Find("Canvas").transform.Find("BlackScreen").gameObject;
        m_Needle = gameObject.transform.Find("Canvas").transform.Find("Clock").transform.Find("Needle").gameObject;
        m_Offset = new Vector3(0, 2.5f, -2.5f);
        Color t_color = m_BlackScreen.GetComponent<RawImage>().color;
        m_BlackScreen.GetComponent<RawImage>().color = new Color(t_color.r, t_color.g, t_color.b, 255);
        StartCoroutine(FadeBlackScreen(-1, 3));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + m_Offset;
    }

    public IEnumerator FadeBlackScreen(float a_direction, float a_Duration)
    {
        float t_ElapsedTime = 0f;
        while (t_ElapsedTime / a_Duration <= 1)
        {
            float t = t_ElapsedTime / a_Duration;
            if(a_direction == -1)
            {
                t = 1 - t;
            }
            Color t_color = m_BlackScreen.GetComponent<RawImage>().color;
            t_color = new Color(t_color.r, t_color.g, t_color.b, Mathf.Lerp(0, 1, t));
            m_BlackScreen.GetComponent<RawImage>().color = t_color;
            //m_Waves[0].TargetTree.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(t_InitialColor, a_NewColor, t));
            t_ElapsedTime += Time.deltaTime;
            yield return null;
        }

        
        yield break;
        
        
        //Debug.Log(m_UiHurtScreen.GetComponent<RawImage>().color);
    }

    public void TickClockNeedle(float Progress)
    {
        //Debug.Log(Progress);
        m_Needle.transform.eulerAngles = new Vector3(0,0,Mathf.Lerp(60, 240, 1 - Progress));
    }
}
