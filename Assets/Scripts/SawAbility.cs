using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAbility : MonoBehaviour
{
    bool isUsing = false;
    private bool _isMove = false;
    private bool moved = false;
    private bool dustActive = false;
    private Vector3 target;
    [SerializeField]
    private ParticleSystem dust;
    private ObstacleChecker obstacle;
    private GameObject HeroGroup;
    public bool Using 
    {
        get {return isUsing; }
    }

    public void UseAbility(GameObject Group, ObstacleChecker obstacleObject)
    {
        obstacle = obstacleObject;
        /*
        HeroGroup = Group;
        isUsing = true;
        _isMove = true;
        dustActive = true;
        target = transform.position;
        target.z += 5f;
         */
        GameObject.Destroy(obstacle.enemyObject.gameObject);

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
         if (Vector3.Distance(gameObject.transform.position, target) < 2f)
        {
            moved = true;
            dust.Play();
            _isMove = false;
        }
    }

    private void FixedUpdate() 
    {
        if(_isMove)
        {
            Move();
        }
        if(dustActive && moved)
        {
            Debug.Log(dust.time);
            if(dust.time > 3.9f)
            {   
                Debug.Log("True");
                GameObject.Destroy(obstacle.enemyObject.gameObject);
                dustActive = false;
            }
            if(!dustActive)
            {
                Debug.Log("ff");
                isUsing = false;
                moved = false;
            }
        }
    }
}
