using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private string heroName;

    public string GetHeroName
    {
        get {return heroName;}
    }

    public void StartMoveAnim()
    {
        var anim = GetComponent<Animator>();
        anim.SetTrigger("StartWalk");
    }

    public void StopMoveAnim()
    {
        var anim = GetComponent<Animator>();
        anim.SetTrigger("StopWalk");
    }

    public void StartAbilityAnim()
    {
        var anim = GetComponent<Animator>();
        anim.SetTrigger("StartAbility");
    }

    public void StopAbilityAnim()
    {
        var anim = GetComponent<Animator>();
        anim.SetTrigger("StopAbility");
    }

}
