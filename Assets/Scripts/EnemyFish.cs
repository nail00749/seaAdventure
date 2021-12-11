using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : MonoBehaviour
{
    private Vector3 targetPoint;
    private bool move;
    private bool attacked;
    private bool escapes;
    private int attackIndex;
    
    public bool SetMove
    {
        set {move = value;}
    }
    public bool FishEscapes
    {
        get {return escapes;}
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "obstacleChecker")
        {
            Debug.Log("True");
            targetPoint = other.transform.position;
            targetPoint.z += 4f;
            targetPoint.y = transform.position.y;
            var anim = GetComponent<Animator>();
            if(!anim.GetBool("Swim"))
                anim.SetBool("Swim",true);
        }    
    }

    private void FixedUpdate() 
    {
        if(move)
        {
            EnemyMove();
        }
        if(attacked)
        {
            AttackChecker();
        }
    }

    private void AttackChecker()
    {
        var anim = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if(anim.IsName("Base Layer.Armature|Attack"))
        {
            attackIndex += 1;
        }
        if(attackIndex == 100)
        {
            escapes = true;
            var animator = GetComponent<Animator>();
            if(animator.GetBool("Ability"))
                animator.SetBool("Ability",false);
            if(!animator.GetBool("Swim"))
                animator.SetBool("Swim",true);
            targetPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z + 100);
            move = true;
            attacked = false;
        }

    }

    private void EnemyMove()
    {
        var targetPos = new Vector3(targetPoint.x, targetPoint.y, targetPoint.z);
        
        transform.position =
            Vector3.MoveTowards(transform.position, 
                targetPos,
                Time.deltaTime * 17f);
        
        var lookPos = targetPos - transform.position;
        lookPos.y = 0;
        if (lookPos != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 17f);
        }
        if (Vector3.Distance(gameObject.transform.position, targetPoint) < 2f)
        {
            move = false;
            var anim = GetComponent<Animator>();
            if(anim.GetBool("Swim"))
                anim.SetBool("Swim",false);
            if(!anim.GetBool("Ability"))
                anim.SetBool("Ability",true);
            attacked = true;
            if(escapes)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

}
