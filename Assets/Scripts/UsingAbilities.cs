using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingAbilities : MonoBehaviour
{
    [SerializeField]
    private MoveController moveController;
    [SerializeField]
    private HeroChanger heroChanger;
    [SerializeField]
    private List<Hero> heroes;
    [SerializeField]
    private ObstacleChecker obstacle;
    [SerializeField]
    private Button UseAbilityButton;
    [SerializeField]
    private Button MoveOnButton;
    private bool isUsing = false;
    [SerializeField]
    private GameObject HeroGroup;

    public List<Hero> GetHeroes
    {
        get {return heroes;}
    }
    public bool Using
    {
        get {return isUsing;}
    }

    public void UseAbilities()
    {
        MoveOnButton.gameObject.SetActive(false);
        UseAbilityButton.gameObject.SetActive(false);
        isUsing = true;
        heroes[heroChanger.GetActiveHeroIndex]
        .GetComponent<IAbilities>()
        .UseAbility(HeroGroup, obstacle, moveController);
    }

    private void FixedUpdate() 
    {
        if(heroes[heroChanger.GetActiveHeroIndex].GetComponent<IAbilities>().Using == false)
        {
            isUsing = false;
        }
    }
}
