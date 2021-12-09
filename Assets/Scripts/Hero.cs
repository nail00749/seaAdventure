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
        if(!anim.GetBool("Swim"))
        {
            anim.SetBool("Swim", true);
        }
        
    }

    public void StopMoveAnim()
    {
        var anim = GetComponent<Animator>();
        if(anim.GetBool("Swim"))
        {
            anim.SetBool("Swim", false);
        }
    }

    public void StartAbilityAnim()
    {
        var anim = GetComponent<Animator>();
        if(!anim.GetBool("Ability"))
        {
            anim.SetBool("Ability", true);
        }
    }

    public void StopAbilityAnim()
    {
        var anim = GetComponent<Animator>();
        if(anim.GetBool("Ability"))
        {
            anim.SetBool("Ability", false);
        }
    }

}
