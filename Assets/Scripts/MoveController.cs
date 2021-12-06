using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 _mouseTarget;
    public bool _isMove;
    private Vector3 _lookPos;
    
    [SerializeField]
    private UsingAbilities usingAbilities;

    [SerializeField]
    private ObstacleChecker obstacle;

    [SerializeField]
    private HeroChanger heroChanger;

    private Vector3 targetPoint;
    public Vector3 GetTarget
    {
        get {return targetPoint;}
        set {targetPoint = value;}
    }
    private bool movesWithoutPhysics;
    public bool GetMovesWithoutPhysics
    {
        get{return movesWithoutPhysics;}
        set{movesWithoutPhysics = value;}
    }

    void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0) && !usingAbilities.Using && !obstacle.GetCollide)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "ground")
            {
                usingAbilities.GetHeroes[heroChanger.GetActiveHeroIndex].StartMoveAnim();
                _isMove = true;
                _mouseTarget = hit.point;
                _lookPos = _mouseTarget - transform.position;
            }
        }

        if (_isMove)
        {
            Move();
        }
        if(movesWithoutPhysics)
        {
            NotPhysicalMovement();
        }
        
    }

    public void Move()
    {
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
        if(Vector3.Distance(target, transform.position) < 5f)
        {
            usingAbilities.GetHeroes[heroChanger.GetActiveHeroIndex].StopMoveAnim();
        }
        if(Vector3.Distance(target, transform.position) < 1f)
        {
            _isMove = false;
        }
    }

    private void NotPhysicalMovement()
    {
        var targetPos = new Vector3(targetPoint.x, targetPoint.y, targetPoint.z);
        
        transform.position =
            Vector3.MoveTowards(transform.position, 
                targetPos,
                Time.deltaTime * 15f);
        
        var lookPos = targetPos - transform.position;
        lookPos.y = 0;
        if (lookPos != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 15f);
        }
        if (Vector3.Distance(gameObject.transform.position, targetPoint) < 2f)
        {
            movesWithoutPhysics = false;
        }
    }
    
}
