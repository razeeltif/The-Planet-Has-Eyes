﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echap : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
