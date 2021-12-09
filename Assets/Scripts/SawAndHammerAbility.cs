using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAndHammerAbility : MonoBehaviour, IAbilities
{
    private bool isUsing;
    private bool dustActive;
    private bool ThisEnemyFish;
    private MoveController moveController;
    [SerializeField]
    private ParticleSystem dust;
    private Enemy enemyObject;
    private GameObject HeroGroup;
    private EnemyFish enemyFish;

    public SawAndHammerAbility()
    {
        isUsing = false;
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
            GetComponent<Hero>().StartAbilityAnim();
            isUsing = true;
            ThisEnemyFish = true;
            enemyFish.GetComponent<EnemyFish>().SetMove = true;
        }
        else
        {
            enemyObject = enemy.GetEnemyObject.GetComponent<Enemy>();
            HeroGroup = Group;
            isUsing = true;
            GetComponent<Hero>().StartAbilityAnim();
            dustActive = true;
            dust.Play();
        }
    }

    private void DustCheck()
    {
        if(dustActive)
        {
            if(dust.time > 3.9f)
            {   
                GameObject.Destroy(enemyObject.gameObject);
                dustActive = false;
                GetComponent<Hero>().StopAbilityAnim();
                dust.Stop();
            }
        }
    }

    private void FixedUpdate() 
    {
        if(!ThisEnemyFish)
        {
            DustCheck();
            if(dust.isStopped && dust.particleCount < 5)
            {
                isUsing = false;
            }
        }
        else
        {
            if(enemyFish.FishEscapes)
            {
                GetComponent<Hero>().StopAbilityAnim();
                isUsing = false;
                ThisEnemyFish = false;
            }
        }

    }
}
