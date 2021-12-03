using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelAbility : MonoBehaviour, IAbilities 
{
    private bool isUsing;
    private Enemy enemyObject;
    private Hero hero;
    private GameObject HeroGroup;
    private MoveController moveController;
    public EelAbility()
    {
        isUsing = false;
    }

    public bool Using 
    {
        get{return isUsing;}
    }

    public void UseAbility(GameObject Group, ObstacleChecker enemy, MoveController move)
    {
        moveController = move;
        enemyObject = enemy.GetEnemyObject.GetComponent<Enemy>();
        HeroGroup = Group;
        var child = FindChildrenByTag(enemyObject.gameObject,"road");
        if(child == null)
            return;
        isUsing = true;
        moveController.GetMovesWithoutPhysics = true;
        moveController.GetTarget = child.transform.position;
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

    private void FixedUpdate() 
    {
        if(moveController != null)
        {
            if(moveController.GetMovesWithoutPhysics == false && isUsing == true)
            {
                isUsing = false;
                enemyObject.GetComponent<MeshCollider>().isTrigger = false;
            }
        }
    }
    
}
