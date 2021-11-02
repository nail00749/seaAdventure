using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 _mouseTarget;
    private bool _isMove;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "ground")
            {
                _isMove = true;
                _mouseTarget = hit.point;
            }
        }

        if (_isMove)
        {
            Move();
        }
    }

    void Move()
    {
        if (Vector3.Distance(gameObject.transform.position, _mouseTarget) < 1f)
        {
            _isMove = false;
        }

        gameObject.transform.position =
            Vector3.MoveTowards(gameObject.transform.position, _mouseTarget, Time.deltaTime * 10f);
        
        Vector3 direction = (_mouseTarget - gameObject.transform.position);
        Quaternion rotation = Quaternion.LookRotation(-direction);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 10f * Time.deltaTime);
        
        
    }
    
}
