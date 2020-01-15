﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 m_Offset;

    // Start is called before the first frame update
    void Start()
    {
        m_Offset = new Vector3(0, 2.5f, -2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + m_Offset;
    }
}
