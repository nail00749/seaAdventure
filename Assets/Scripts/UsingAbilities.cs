using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingAbilities : MonoBehaviour
{
    [SerializeField]
    private HeroChanger heroChanger;
    [SerializeField]
    private List<Hero> heroes;
    [SerializeField]
    private ObstacleChecker obstacle;
    [SerializeField]
    private Button UseAbilityButton;
    private bool isUsing = false;
    [SerializeField]
    private GameObject HeroGroup;

    public bool Using
    {
        get {return isUsing;}
    }

    public void UseAbilities()
    {
        UseAbilityButton.gameObject.SetActive(false);
        var index = heroChanger.GetActiveHeroIndex;
        isUsing = true;
        switch (index)
        {
            case 0: heroes[index].GetComponent<EelAbility>().UseAbility(HeroGroup, obstacle);
                break;
            case 1: heroes[index].GetComponent<HammerAbility>().UseAbility(HeroGroup, obstacle);
                break;
            case 2: heroes[index].GetComponent<HedgehogAbility>().UseAbility(HeroGroup, obstacle);
                break;
            case 3: heroes[index].GetComponent<SawAbility>().UseAbility(HeroGroup, obstacle); 
                break;
            case 4: heroes[index].GetComponent<TurtleAbility>().UseAbility(HeroGroup, obstacle);
                break;
            
        }
        isUsing = false;
    }
}
