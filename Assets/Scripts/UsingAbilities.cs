using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingAbilities : MonoBehaviour
{
    private delegate void Methods();
    private Dictionary<string, Methods> abilitiesDict;
    public HeroChanger heroChanger;
    public List<Hero> heroes;
    void Start()
    {
        abilitiesDict = new Dictionary<string, Methods>();
        var hero = new Hero();
        abilitiesDict.Add("saw", new Methods(hero.SawAbility));
        abilitiesDict.Add("turtle", new Methods(hero.TurtlesAbility));
        abilitiesDict.Add("hammer", new Methods(hero.HammerAbility));
        abilitiesDict.Add("hedgehog", new Methods(hero.HedgehogAbility));
        abilitiesDict.Add("eel", new Methods(hero.EelAbility));
    }

    public void UseAbilities()
    {
        var index = heroChanger.GetActiveHeroIndex;
        var hero = heroes[index];
        abilitiesDict[hero.heroName]();
    }
}
