using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogAbility : MonoBehaviour, IAbilities 
{
    private Enemy enemyObject;
    private bool isUsing;
    private bool firstPoint;
    private GameObject HeroGroup;
    public bool Using 
    {
        get{return isUsing;}
    }
    private MoveController moveController;
    private Vector3 PrevTarget;

    public void UseAbility(GameObject Group, ObstacleChecker enemy, MoveController move)
    {
        moveController = move;
        HeroGroup = Group;
        enemyObject = enemy.GetEnemyObject.GetComponent<Enemy>();
        var child = FindChildrenByTag(enemyObject.gameObject,"hole");
        if(child == null)
            return;
        isUsing = true;
        GetComponent<Hero>().StartAbilityAnim();
        moveController.GetTarget = child.transform.position;
        PrevTarget = child.transform.position;
        moveController.GetMovesWithoutPhysics = true;
        HeroGroup.GetComponent<Rigidbody>().useGravity = false;
        enemyObject.GetComponent<MeshCollider>().isTrigger = true;
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

    private void CheckPosition()
    {
        if(moveController.GetMovesWithoutPhysics == false && !firstPoint && isUsing == true)
        {
            moveController.GetTarget = new Vector3(PrevTarget.x, PrevTarget.y, PrevTarget.z + 10f);
            moveController.GetMovesWithoutPhysics = true;
            firstPoint = true;
        }
        if(moveController.GetMovesWithoutPhysics == false && firstPoint == true)
        {
            isUsing = false;
            firstPoint = false;
            HeroGroup.GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Hero>().StopAbilityAnim();
            enemyObject.GetComponent<MeshCollider>().isTrigger = false;
        }
    }

    private void FixedUpdate() 
    {   if(moveController != null)
        {
            CheckPosition();
        }
    }
}
