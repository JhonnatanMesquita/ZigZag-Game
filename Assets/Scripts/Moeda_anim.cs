﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda_anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(120 * Time.deltaTime, 0, 0));
    }
}
