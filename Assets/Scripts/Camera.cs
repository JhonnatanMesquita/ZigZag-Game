using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform bolinha;

    private float lerpVal = 1f;
    private Vector3 dist, camPos, bolPos;


    void Start()
    {
        dist = bolinha.position - transform.position;    
    }

    void LateUpdate()
    {
        if (!Main_bolinha.gameOver)
        {
            camPos = transform.position;
            bolPos = bolinha.position - dist;
            camPos = Vector3.Lerp(camPos, bolPos, lerpVal);
            transform.position = camPos;
        }
    }
}
