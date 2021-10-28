using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 Offset;
    private bool isMoving;
    private Vector3 PositionHero;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        HeroMove.IsMoving += HeroMove_IsMoving;
    }

    private void HeroMove_IsMoving(Vector3 positionHero)
    {
        
        PositionHero = positionHero;
        Offset = transform.position - positionHero;
        isMoving = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.position = new Vector3(PositionHero.x + Offset.x, PositionHero.y + Offset.y, PositionHero.z);
            isMoving = false;
        }
    }
}
