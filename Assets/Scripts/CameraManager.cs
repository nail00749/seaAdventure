using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Animator Shake;
    private Vector3 Offset;
    public GameObject HeroGroup;
    private List<GameObject> enemyObjects;

    // Start is called before the first frame update
    void Start()
    {
        enemyObjects = new List<GameObject>();
        CollisionManager.CollisionEnter += ShakeCamera;
        Offset = transform.position - HeroGroup.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = HeroGroup.transform.position + Offset;
    }



    private void ShakeCamera(GameObject gameObject)
    {
        if(!enemyObjects.Contains(gameObject))
        {
            enemyObjects.Add(gameObject);
            Shake.SetTrigger("Shake");
        }
        
    }
}
