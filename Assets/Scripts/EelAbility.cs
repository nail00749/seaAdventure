using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelAbility : MonoBehaviour
{
    private Vector3 target;
    private bool isUsing;
    private bool _isMove;
    private ObstacleChecker obstacle;
    private Hero hero;
    private GameObject HeroGroup;
    public bool Using 
    {
        get{return isUsing;}
    }

    public void UseAbility(GameObject Group, ObstacleChecker obstacleObject)
    {
       /* HeroGroup = Group;
        obstacle = obstacleObject;
        var child = FindChildrenByTag(obstacle.enemyObject.gameObject,"road");
        if(child == null)
            return;
        target = child.transform.position;
        isUsing = true;
        _isMove = true;
        */
        obstacleObject.enemyObject.GetComponent<BoxCollider>().isTrigger = true;
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
