using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 _mouseTarget;
    public bool _isMove;
    private Vector3 _lookPos;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "ground")
            {
                _isMove = true;
                _mouseTarget = hit.point;
                _lookPos = _mouseTarget - transform.position;
            }
        }

        if (_isMove)
        {
            Move();
        }

        
    }

    public void Move()
    {
        /*!!!
        if (Vector3.Distance(gameObject.transform.position, _mouseTarget) < 1f)
        {
            _isMove = false;
        }

        Vector3 target = new Vector3(_mouseTarget.x, 3, _mouseTarget.z);
        
        gameObject.transform.position =
            Vector3.MoveTowards(gameObject.transform.position, 
                target,
                Time.deltaTime * 10f);
        */
        /*Vector3 direction = (_mouseTarget - gameObject.transform.position);
        if (direction != Vector3.zero) {
            Quaternion rotation = Quaternion.LookRotation(-direction);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 10f * Time.deltaTime);
        }*/

        /*!!!
        var lookPos = _mouseTarget - transform.position;
        lookPos.y = 0;
        if (lookPos != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
        }
        */
        

        Vector3 target = new Vector3(_mouseTarget.x, 3, _mouseTarget.z);
        var direction = target - transform.position;
        var rigidBody = GetComponent<Rigidbody>();
        
        if (rigidBody.velocity.magnitude > 10f) 
        {
            rigidBody.velocity = rigidBody.velocity.normalized * 10f;
        }
        rigidBody.AddForce(direction.normalized, ForceMode.VelocityChange);

        _lookPos.y = 0;
        if (_lookPos != Vector3.zero)
        {   
            var rotation = Quaternion.LookRotation(_lookPos);
            rigidBody.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
                
        }  
        target.y = transform.position.y;
        if(Vector3.Distance(target, transform.position) < 1f)
        {
            _isMove = false;
        }
    }
    
}
