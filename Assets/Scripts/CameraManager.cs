using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 Offset;
    public GameObject HeroGroup;

    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - HeroGroup.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = HeroGroup.transform.position + Offset;
    }
    
}
