using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAndHammerAbility : MonoBehaviour, IAbilities
{
    private bool isUsing;
    private bool moved;
    private bool dustActive;
    private MoveController moveController;
    [SerializeField]
    private ParticleSystem dust;
    private Enemy enemyObject;
    private GameObject HeroGroup;
    private EnemyFish enemyFish;

    public SawAndHammerAbility()
    {
        isUsing = false;
        moved = false;
        dustActive = false;
    }

    public bool Using 
    {
        get {return isUsing; }
    }

    public void UseAbility(GameObject Group, ObstacleChecker enemy, MoveController move)
    {
        moveController = move;
        if(enemy.GetEnemyObject.GetComponent<EnemyFish>() != null)
        {
            enemyFish = enemy.GetEnemyObject.GetComponent<EnemyFish>();
            
        }
        else
        {
            enemyObject = enemy.GetEnemyObject.GetComponent<Enemy>();
            HeroGroup = Group;
            isUsing = true;
            dustActive = true;
            //moveController.GetTarget = new Vector3(transform.position.x,transform.position.y, transform.position.z + 5f);
            //moveController.GetMovesWithoutPhysics = true;
            dust.Play();
            moved = true;
            isUsing = false;
        }
    }

    private void MoveCheck()
    {
        if(moveController != null)
        {
            if(isUsing && moveController.GetMovesWithoutPhysics == false)
            {
                dust.Play();
                moved = true;
            }
        }
    }

    private void DustCheck()
    {
        if(dustActive && moved)
        {
            if(dust.time > 3.9f)
            {   
                GameObject.Destroy(enemyObject.gameObject);
                dustActive = false;
            }
            /*if(!dustActive)
            {
                isUsing = false;
                moved = false;
            }
            */
        }
        if(dust.isStopped)
        {
            isUsing = false;
        }
    }

    private void FixedUpdate() 
    {
        MoveCheck();
        DustCheck();
    }
}
