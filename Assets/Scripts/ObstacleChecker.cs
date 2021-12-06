using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleChecker : MonoBehaviour
{   
    [SerializeField]
    private MoveController heroGroupMoveController;
    [SerializeField]
    private Text textObstacle;
    [SerializeField]
    private List<Hero> Heroes;
    [SerializeField]
    private HeroChanger heroGroupHeroChanger;
    [SerializeField]
    private Button UseAbilityButton;
    [SerializeField]
    private Button ChangeHeroButton;
    private GameObject enemyObject;
    private int prevHeroIndex;
    private bool collide;

    public bool GetCollide
    {
        get {return collide;}
    }
    public GameObject GetEnemyObject
    {
        get {return enemyObject;}
    }

    void Start()
    {
        collide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            collide = true;
            heroGroupMoveController._isMove = false;
            Heroes[heroGroupHeroChanger.GetActiveHeroIndex].GetComponent<Hero>().StopMoveAnim();
            enemyObject = other.gameObject;
            CheckHeroAndEnemy();
        }
    }

    private void CheckHeroAndEnemy()
    {
        var currentPassingObject = enemyObject.GetComponent<Enemy>().passingObject;
        var currentHeroName = Heroes[heroGroupHeroChanger.GetActiveHeroIndex].GetHeroName;
        Debug.Log(currentHeroName + " - Hero| " + currentPassingObject + " - Object");
        if (currentPassingObject == currentHeroName)
        {
            collide = false;
            UseAbilityButton.gameObject.SetActive(true);
        }
        else
        {
            prevHeroIndex = heroGroupHeroChanger.GetActiveHeroIndex;
            ChangeHeroButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collide = false;
        UseAbilityButton.gameObject.SetActive(false);
        ChangeHeroButton.gameObject.SetActive(false);
    }

    private void FixedUpdate() 
    {
        if(prevHeroIndex != heroGroupHeroChanger.GetActiveHeroIndex && collide)
        {
            ChangeHeroButton.gameObject.SetActive(false);
            CheckHeroAndEnemy();
        }
    }
}