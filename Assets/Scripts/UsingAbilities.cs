using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingAbilities : MonoBehaviour
{
    public HeroChanger heroChanger;
    public List<Hero> heroes;
    public ObstacleChecker obstacle;
    public Button UseAbilityButton;
    private bool _isMove = false;
    private bool _inHole = false;
    private Vector3 target;
    private ParticleSystem dust;

    public void UseAbilities()
    {
        var index = heroChanger.GetActiveHeroIndex;
        switch (index)
        {
            case 0: EelAbility(heroes[index]);
                break;
            case 1: HammerAbility(heroes[index]);
                break;
            case 2: HedgehogAbility(heroes[index]);
                break;
            case 3: SawAbility(heroes[index]); 
                break;
            case 4: TurtlesAbility(heroes[index]);
                break;
            
        }
        UseAbilityButton.gameObject.SetActive(false);
    }
    private void SawAbility(Hero hero)
    {
        int count = hero.transform.childCount;
        for (var i = 0; i < count; i++)
        {
            if(hero.transform.GetChild(i).tag == "dust")
            {
                dust = hero.transform.GetChild(i).GetComponent<ParticleSystem>();
                dust.Play();
                return;
            }
        } 
    }
    private void TurtlesAbility(Hero hero)
    {
        //Прячется в панцирь
        Debug.Log("Способность черепахи");
    }
    private void HedgehogAbility(Hero hero)
    {
        hero.transform.localScale = new Vector3(1,1,1);

        int count = obstacle.enemyObject.transform.childCount; 
        Transform enter = null;
        for (var i = 0; i < count; i++)
        {
            enter = obstacle.enemyObject.transform.GetChild(i);
            if(enter.tag == "hole")
            {
                target = enter.transform.position;
                _isMove = true;
                GetComponent<Rigidbody>().useGravity = false;
                return;
            }
                
        }
    }
    private void EelAbility(Hero hero)
    {
        obstacle.enemyObject.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
    private void HammerAbility(Hero hero)
    {
        int count = hero.transform.childCount;
        for (var i = 0; i < count; i++)
        {
            if(hero.transform.GetChild(i).tag == "dust")
            {
                dust = hero.transform.GetChild(i).GetComponent<ParticleSystem>();
                dust.Play();
                return;
            }
        } 
    }   
    private void FixedUpdate() 
    {
        if (_isMove)
        {
            Move();
        }
        if(dust != null && dust.isPlaying)
        {
            Debug.Log(dust.time);
            if(dust.time > 3.9f)
            {
                GameObject.Destroy(obstacle.enemyObject.gameObject);
                dust = null;
                Debug.Log("2");
            }
        }
        
    }   
    private void Move()
    {
        var targetPos = new Vector3(target.x, target.y, target.z);
        
        gameObject.transform.position =
            Vector3.MoveTowards(gameObject.transform.position, 
                targetPos,
                Time.deltaTime * 15f);
        
        var lookPos = targetPos - transform.position;
        lookPos.y = 0;
        if (lookPos != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 15f);
        }

        if (Vector3.Distance(gameObject.transform.position, target) < 2f && !_inHole)
        {
            _inHole = true;
            target.z += 10f;
            target.y = transform.position.y;
        }
        else if(Vector3.Distance(gameObject.transform.position, target) < 2f && _inHole)
        {
            _inHole = false;
            _isMove = false;
            GetComponent<Rigidbody>().useGravity = true;
            heroes[heroChanger.GetActiveHeroIndex].transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }
    }
}
