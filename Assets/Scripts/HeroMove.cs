using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public delegate void MoveHeroDelegate(Vector3 positionHero);

    public static event MoveHeroDelegate IsMoving;

    private bool isMoving;
    private Vector3 TargetPosition;
    private float speed;
    ClickHandler click;
    public GameObject Location;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        speed = 2f;
        ClickHandler.IsClicked += Click_IsClicked;
    }

    private void Click_IsClicked(Vector3 args)
    {
        Ray ray = Camera.main.ScreenPointToRay(args);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            TargetPosition = hit.point;
        }

        transform.LookAt(TargetPosition);

        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Move();
        }   
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
        IsMoving?.Invoke(transform.position);

        if ((int)(transform.position.x) == (int)(TargetPosition.x) && (int)(transform.position.z) == (int)(TargetPosition.z)) 
        {
            isMoving = false;
        }
           
    }
    
}
