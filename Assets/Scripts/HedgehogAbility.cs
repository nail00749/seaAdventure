using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogAbility : MonoBehaviour
{
    private ObstacleChecker obstacle;
    private bool isUsing;
    private Vector3 target;
    private bool _isMove;
    private bool firstPoint;
    private GameObject HeroGroup;
    public bool Using 
    {
        get{return isUsing;}
    }

    public void UseAbility(GameObject Group, ObstacleChecker obstacleObject)
    {
        HeroGroup = Group;
        obstacle = obstacleObject;
        var child = FindChildrenByTag(obstacle.enemyObject.gameObject,"hole");
        if(child == null)
            return;
        isUsing = true;
        transform.localScale = new Vector3(1,1,1);
        target = child.transform.position;
        _isMove = true;
        HeroGroup.GetComponent<Rigidbody>().useGravity = false;
    }


    private void Move()
    {
        var targetPos = new Vector3(target.x, target.y, target.z);
        
        HeroGroup.transform.position =
            Vector3.MoveTowards(HeroGroup.transform.position, 
                targetPos,
                Time.deltaTime * 15f);
        
        var lookPos = targetPos - HeroGroup.transform.position;
        lookPos.y = 0;
        if (lookPos != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(lookPos);
            HeroGroup.transform.rotation = Quaternion.Slerp(HeroGroup.transform.rotation, rotation, Time.deltaTime * 15f);
        }

        if (Vector3.Distance(HeroGroup.transform.position, target) < 2f && !firstPoint)
        {
            firstPoint = true;
            target.z += 10f;
            target.y = transform.position.y;
        }
        else if(Vector3.Distance(HeroGroup.transform.position, target) < 2f && firstPoint)
        {
            isUsing = false;
            firstPoint = false;
            _isMove = false;
            HeroGroup.GetComponent<Rigidbody>().useGravity = true;
            transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }
        
    }

    private Transform FindChildrenByTag(GameObject parant ,string tag)
    {
        Transform children = null; 
        for (var i = 0; i < parant.transform.childCount; i++)
        {
            if(parant.transform.GetChild(i).tag == tag)
            {
                return parant.transform.GetChild(i);
            }
                
        }
        return children;
    }

    private void FixedUpdate() 
    {
        if(_isMove)
        {
            Move();
        }
    }
}
