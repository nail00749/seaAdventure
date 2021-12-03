using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Group")
        {
            var index = other.gameObject.GetComponent<HeroChanger>().GetActiveHeroIndex;
            var heroes = other.gameObject.GetComponent<UsingAbilities>().GetHeroes;
            var passigObject = GetComponent<Enemy>().passingObject;
            var heroName = heroes[index].GetHeroName;
            if(passigObject == heroName)
            {
                Debug.Log(passigObject  + "=" + heroName + "= True");
            }
            else
            {
                Debug.Log(passigObject  + "=" + heroName + "= False");
            }
        }
    }
}
