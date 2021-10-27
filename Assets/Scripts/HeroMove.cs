using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    private bool isMoving;
    private Vector3 TargetPosition;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            SetTargetPosition();
        if (isMoving)
            Move();
    }

    private void SetTargetPosition()
    {
        TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TargetPosition.z = 20;
        isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
        if (transform.position == TargetPosition)
            isMoving = false;
    }


}
